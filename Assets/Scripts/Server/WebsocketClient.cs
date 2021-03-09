using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.WebSockets;
using System.Threading;
using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class WebsocketClient
{
    //TODO: redo this entire thing
    //code taken from Sky without permision
    public ClientWebSocket ws = new ClientWebSocket();
    private UTF8Encoding encoder; // For websocket text message encoding.
    private const UInt64 MAXREADSIZE = 1 * 1024 * 1024;
    // Server address
    private Uri serverUri;
    // Queues
    public ConcurrentQueue<String> receiveQueue { get; set; }
    public BlockingCollection<ArraySegment<byte>> sendQueue { get; set; }
    // Threads
    private Thread receiveThread { get; set; }
    private Thread sendThread { get; set; }
    //Connection values
    public int statsValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:WebSocketHandler"/> class.
    /// </summary>
    /// <param name="serverURL">Server URL.</param>
    public WebsocketClient(string serverURL = "ws://127.0.0.1:8000/")
    {
        encoder = new UTF8Encoding();
        ws = new ClientWebSocket();
        serverUri = new Uri(serverURL);
        receiveQueue = new ConcurrentQueue<string>();
        receiveThread = new Thread(RunReceive);
        receiveThread.Start();
        sendQueue = new BlockingCollection<ArraySegment<byte>>();
        sendThread = new Thread(RunSend);
        sendThread.Start();
        //ConnectToServer();
    }
    public async void ConnectToServer()
    {
        await this.Connect();
    }
    /// <summary>
    /// Method which connects client to the server.
    /// </summary>
    /// <returns>The connect.</returns>
    public async Task Connect()
    {
        Debug.Log("Connecting to: " + serverUri);

        try
        {
            await ws.ConnectAsync(serverUri, CancellationToken.None);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            await this.Connect();
        }

        while (IsConnecting())
        {
            Debug.Log("Waiting to connect...");
            statsValue = 2;
            Task.Delay(50).Wait();
        }
        Debug.Log("Connect status: " + ws.State);

        if (ws.State == WebSocketState.Open)
        {
            statsValue = 3;
        }
    }

    public async Task CloseConnection()
    {
        Debug.Log("Closing Connection to WSS");
        try
        {
            await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);

            while (IsConnectionOpen())
            {
                Debug.Log("Waiting for connection to close...");
                Task.Delay(50).Wait();
                Debug.Log("test");
            }

            Debug.Log("Connection status: " + ws.State);
            ws.Dispose();
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    public void HeartbeatAsync()
    {
        Send("HB");
    }

    public int GetStatsValue()
    {
        return statsValue;
    }

    #region [Status]
    /// <summary>
    /// Return if is connecting to the server.
    /// </summary>
    /// <returns><c>true</c>, if is connecting to the server, <c>false</c> otherwise.</returns>
    public bool IsConnecting()
    {
        return ws.State == WebSocketState.Connecting;
    }
    /// <summary>
    /// Return if connection with server is open.
    /// </summary>
    /// <returns><c>true</c>, if connection with server is open, <c>false</c> otherwise.</returns>
    public bool IsConnectionOpen()
    {
        return ws.State == WebSocketState.Open;
    }
    #endregion
    #region [Send]
    /// <summary>
    /// Method used to send a message to the server.
    /// </summary>
    /// <param name="message">Message.</param>
    public void Send(string message)
    {
        byte[] buffer = encoder.GetBytes(message);
        //Debug.Log("Message to queue for send: " + buffer.Length + ", message: " + message);
        var sendBuf = new ArraySegment<byte>(buffer);
        sendQueue.Add(sendBuf);
    }
    /// <summary>
    /// Method for other thread, which sends messages to the server.
    /// </summary>
    private async void RunSend()
    {
        Debug.Log("WebSocket Message Sender looping.");
        ArraySegment<byte> msg;
        while (true)
        {
            while (!sendQueue.IsCompleted)
            {
                msg = sendQueue.Take();
                //Debug.Log("Dequeued this message to send: " + msg);
                await ws.SendAsync(msg, WebSocketMessageType.Text, true /* is last part of message */, CancellationToken.None);
            }
        }
    }
    #endregion
    #region [Receive]
    /// <summary>
    /// Reads the message from the server.
    /// </summary>
    /// <returns>The message.</returns>
    /// <param name="maxSize">Max size.</param>
    private async Task<string> Receive(UInt64 maxSize = MAXREADSIZE)
    {
        // A read buffer, and a memory stream to stuff unknown number of chunks into:
        byte[] buf = new byte[4 * 1024];
        var ms = new MemoryStream();
        ArraySegment<byte> arrayBuf = new ArraySegment<byte>(buf);
        WebSocketReceiveResult chunkResult = null;
        while (ws.State == WebSocketState.Open)
        {
            do
            {
                try
                {
                    chunkResult = await ws.ReceiveAsync(arrayBuf, CancellationToken.None);
                }
                catch (WebSocketException e)
                {
                    if (e.WebSocketErrorCode == WebSocketError.ConnectionClosedPrematurely)
                    {
                        Debug.LogError("Premature Disconnection");
                        receiveThread.Abort();
                        sendThread.Abort();
                        statsValue = 1;
                    }
                }
                ms.Write(arrayBuf.Array, arrayBuf.Offset, chunkResult.Count);
                //Debug.Log("Size of Chunk message: " + chunkResult.Count);
                if ((UInt64)(chunkResult.Count) > MAXREADSIZE)
                {
                    Console.Error.WriteLine("Warning: Message is bigger than expected!");
                }
            } while (!chunkResult.EndOfMessage);
            ms.Seek(0, SeekOrigin.Begin);
            // Looking for UTF-8 JSON type messages.
            if (chunkResult.MessageType == WebSocketMessageType.Text)
            {
                return StreamToString(ms, Encoding.UTF8);
            }
        }

        if (ws.State == WebSocketState.Aborted)
        {
            Debug.LogError("Websocket Aborted");
            receiveThread.Abort();
            sendThread.Abort();

            receiveThread = null;
            sendThread = null;
            statsValue = 1;
        }
        else if (ws.State == WebSocketState.Closed)
        {
            Debug.LogError("Websocket Closed");
            receiveThread.Abort();
            sendThread.Abort();

            receiveThread = null;
            sendThread = null;
            statsValue = 2;
        }
        else if (ws.State == WebSocketState.CloseReceived)
        {
            Debug.LogWarning("Websocket Close Received");
            receiveThread.Abort();
            sendThread.Abort();

            receiveThread = null;
            sendThread = null;
            statsValue = 2;
        }
        else if (ws.State == WebSocketState.CloseSent)
        {
            Debug.LogWarning("Websocket close sent");
            statsValue = 3;
        }
        return "";
    }

    /// <summary>
    /// Method for other thread, which receives messages from the server.
    /// </summary>
    private async void RunReceive()
    {
        Debug.Log("WebSocket Message Receiver looping.");
        string result;
        while (true)
        {
            //Debug.Log("Awaiting Receive...");
            result = await Receive();
            if (result != null && result.Length > 0)
            {
                receiveQueue.Enqueue(result);
            }
            else
            {
                Task.Delay(50).Wait();
            }
        }
    }
    #endregion

    public static string StreamToString(MemoryStream ms, Encoding encoding)
    {
        string readString = "";
        if (encoding == Encoding.UTF8)
        {
            using (var reader = new StreamReader(ms, encoding))
            {
                readString = reader.ReadToEnd();
            }
        }
        return readString;
    }
}
