using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuGM : MonoBehaviour
{
    public Text[] displays = new Text[8];

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ClientWS.clientWs.controllers.Length; i++)
        {
            if(ClientWS.clientWs.controllers[i] != null)
            {
                if (ClientWS.clientWs.controllers[i] is WebSocketController)
                {
                    WebSocketController w = (WebSocketController)ClientWS.clientWs.controllers[i];
                    displays[i].text = w.username;
                }else
                {
                    displays[i].text = "Local " + (i + 1);
                }
            }
        }
    }
}
