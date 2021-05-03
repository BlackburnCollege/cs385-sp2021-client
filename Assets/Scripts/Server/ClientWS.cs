using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClientWS : MonoBehaviour
{
    WebsocketClient wc;
    private static ClientWS _clientWs;
    public static ClientWS clientWs{ get { return _clientWs; } set { _clientWs = value; } }
    public JsonObjects jo;
    private int index = 0;
    private string[] names = new string[8];
    public Controllable[] controllers = new Controllable[8];
    private List<int> localControllers = new List<int>();
    public string token = "Awaiting Token";
    Dictionary<string,WebSocketController> websocketPlayers;
    
    // Start is called before the first frame update
    void Start()
    {
        if(clientWs != null)
        {
            Destroy(this.gameObject);
            return;
        }else
        {
            clientWs = this;
        }
        DontDestroyOnLoad(gameObject);
        websocketPlayers = new Dictionary<string, WebSocketController>();
    }

    private void Awake()
    {
        StartConnecion();
    }

    public async void StartConnecion()
    {
        wc = new WebsocketClient();
        await wc.Connect();
    }

    // Update is called once per frame
    void Update()
    {
        if (wc != null || !wc.IsConnecting())
        {
            // Check if server send new messages
            var cqueue = wc.receiveQueue;
            string msg;
            while (cqueue.TryPeek(out msg))
            {
                // Parse newly received messages
                cqueue.TryDequeue(out msg);
                Debug.Log(msg);
                handleMessage(msg);
            }
        }
        if (index < controllers.Length)
        {
            for (int i = 1; i < 9; i++)
            {
                if (InputManger.InputA(i))
                {
                    if (!localControllers.Contains(i))
                    {
                        StandardController s = gameObject.AddComponent<StandardController>();
                        s.connectedContNum = i;
                        controllers[index] = s;
                        index++;
                        localControllers.Add(i);
                    }
                }
            }
        }
        
    }

    public void handleMessage(string msg)
    {
        Debug.Log(msg);
        JsonObjects.JsonHeader header = jo.deserilize<JsonObjects.JsonHeader>(msg);
        if (header.type == "user")
        {
            JsonObjects.User user = jo.deserilize<JsonObjects.User>(header.jsonBlock);
            if (websocketPlayers.ContainsKey(user.name))
            {
                WebSocketController controller = websocketPlayers[user.name];
                controller.joy1 = new Vector2(user.controller.joystick.x, user.controller.joystick.y);
                controller.a = user.controller.a;
                controller.b = user.controller.b;
                controller.x = user.controller.x;
                controller.y = user.controller.y;
                controller.username = user.name;
                controller.ip = user.ip;

            }
            else if (index < controllers.Length)
            {
                WebSocketController w = gameObject.AddComponent<WebSocketController>();
                websocketPlayers.Add(user.name, w);
                if (index < controllers.Length)
                {
                    controllers[index] = websocketPlayers[user.name];
                    index++;
                }

            }
        }else if(header.type == "Token")
        {
            JsonObjects.Token tokenObj = jo.deserilize<JsonObjects.Token>(header.jsonBlock);
            this.token = tokenObj.token;
        }
    }
}
