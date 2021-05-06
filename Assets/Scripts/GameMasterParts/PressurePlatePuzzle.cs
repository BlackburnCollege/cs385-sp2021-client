using System.Collections;
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
    /// <summary>
    /// This checks to see how many players are on the pressure plate and if all of them are on it the puzzle completes
    /// </summary>

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


    /// <summary>
    /// This removes the player if they leave the pad
    /// </summary>

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

    public void StartPuzzle()
    {

    }
}
