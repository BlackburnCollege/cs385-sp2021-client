using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaster : MonoBehaviour
{
    public GameObject[] puzzlesobj = new GameObject[10];
    public Puzzles[] puzzles;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        puzzles = new Puzzles[puzzlesobj.Length];
        for (int i = 0; i < puzzlesobj.Length; i++)
        {
            puzzles[i] = puzzlesobj[i].GetComponent<Puzzles>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Puzzles puzzle in puzzles)
        {
            if (!puzzle.PuzzleCompleted)
            {
                return;
            }
        }
        door.SetActive(false);
    }
}
