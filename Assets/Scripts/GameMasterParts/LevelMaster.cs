using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaster : MonoBehaviour
{
    public List<Puzzles> puzzles = new List<Puzzles>();
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach ( Puzzles puzzle in puzzles)
        {
            if (!puzzle.PuzzleCompleted)
            {
                return;
            }
        }
        door.SetActive(false);
    }
}
