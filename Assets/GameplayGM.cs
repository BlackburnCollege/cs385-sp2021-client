﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayGM : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject[] spawnPoints = new GameObject[8];
     
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ClientWS.clientWs.controllers.Length; i++)
        {
            if(ClientWS.clientWs.controllers[i] != null)
            {
                GameObject go = Instantiate(PlayerPrefab);
                go.transform.position = spawnPoints[i].transform.position;
                go.GetComponent<PlayerMovement>().controller = ClientWS.clientWs.controllers[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
