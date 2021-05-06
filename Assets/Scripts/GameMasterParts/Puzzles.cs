using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This interface makes it so that we can make multiple puzzles by implementing this code
/// </summary>

public interface Puzzles
{
    bool PuzzleCompleted{ get; set; }

    void StartPuzzle();
   
}
