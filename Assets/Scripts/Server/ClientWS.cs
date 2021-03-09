using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClientWS : MonoBehaviour
{
    WebsocketClient wc;
    public JsonObjects jo;
    private int index = 0;
    public Text[] playersNames= new Text[8];
    private string[] names = new string[8];
    Dictionary<string,Text> players;
    
    // Start is called before the first frame update
    void Start()
    {
        players = new Dictionary<string, Text>();
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
    }

    public void handleMessage(string msg)
    {
        JsonObjects.User user = jo.deserilize<JsonObjects.User>(msg);
        if(players.ContainsKey(user.name))
        {
            players[user.name].text = user.name + " joyx:" + user.controller.joystick.x;
        }else if(index < playersNames.Length)
        {
            players.Add(user.name, playersNames[index]);
            index++;
            players[user.name].text = user.name + " joyx:" + user.controller.joystick.x;
        }
    }
}
