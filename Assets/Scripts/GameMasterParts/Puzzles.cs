using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This interface makes it so that we can make multiple puzzles by implementing this code
public interface Puzzles
{
    bool PuzzleCompleted{ get; set; }

    void StartPuzzle();
   
}
