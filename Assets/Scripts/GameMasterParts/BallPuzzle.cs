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


    public void Reset()
    {
        foreach (BallButton button in ballButtons)
        {
            button.numberOfClicks = 0;
            button.GiveHint();
        }
    }

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

    public void StartPuzzle()
    {
        foreach (BallButton i in ballButtons)
        {
            i.GiveHint();
        }
    }
}
