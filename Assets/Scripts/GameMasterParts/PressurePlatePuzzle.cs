﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PressurePlatePuzzle : MonoBehaviour, Puzzles
{
    public bool PuzzleCompleted {get; set; }

    // Start is called before the first frame update
    void Start()
    {
        PuzzleCompleted = false;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private List<Player> players = new List<Player>();

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!players.Contains(collision.gameObject.GetComponent<Player>()))
            {
                players.Add(collision.gameObject.GetComponent<Player>());
                if (GameplayGM.gamplayGM.Players.Count == players.Count)
                {
                    PuzzleCompleted = true;
                    Debug.Log("puzzle complete");
                }
            }
        }
    }



    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (players.Contains(collision.gameObject.GetComponent<Player>()))
            {
                players.Remove(collision.gameObject.GetComponent<Player>());
            }
        }
    }
}