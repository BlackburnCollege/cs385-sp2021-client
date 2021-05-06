using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPuzzle : MonoBehaviour , Puzzles
{
    public bool PuzzleCompleted { get; set; }
    public List<BallButton> ballButtons;
    // Start is called before the first frame update
    void Start()
    {
        foreach (BallButton ballButton in ballButtons)
        {
            ballButton.ballPuzzle = this;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Complete())
        {
            PuzzleCompleted = true;
        }
        Checkstatus();
    }

    // if the puzzle is done incorrectly it will reset
    public void Reset()
    {
        foreach (BallButton button in ballButtons)
        {
            button.numberOfClicks = 0;
            button.GiveHint();
        }
    }
    //This see if the puzzle is complete
    private bool Complete()
    {
        foreach (BallButton item in ballButtons)
        {
            if (item.numberOfClicks != item.clicksRequired)
            {
                return false;
            }
        }
        return true;
    }
    //this checks how many times the ball has been clicked and if it is the color changes to indicate success
    public void Checkstatus()
    {
        foreach (BallButton item in ballButtons)
        {
            if (PuzzleCompleted)
            {
                item.mat.color = item.succes;
            }
        }
    }
    //This starts the puzzle and gives a hint of how many times a ball needs to be clicked
    public void StartPuzzle()
    {
        foreach (BallButton i in ballButtons)
        {
            i.GiveHint();
        }
    }
}
