using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// </summary>
public class Timer : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public float timeRemaining = 0;
    public bool timerIsRunning = false;

    private void Start()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    public void setTimer(int time)
    {
        timeRemaining = time;
        timerIsRunning = true;
    }


}
