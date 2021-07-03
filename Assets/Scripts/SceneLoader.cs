using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //goToSettings changes the scene from what ever scene you are on to the settings scene
    public void goToSettings()
    {
        Debug.Log("ran");
        SceneManager.LoadScene("Settings");
    }

    //goToPlay changes the scene from what ever scene you are on to the play scene
    public void goToPlay()
    {
        if (ClientWS.clientWs.controllers[0] != null)
        {
            Debug.Log("ran");
            SceneManager.LoadScene("Play");
        }
        else
        {
            Debug.Log("Not Enough Players to Start");
        }
    }

    //goToMainMenu changes the scene from what ever scene you are on to the MainMenu scene
    public void goToMainMenu()
    {
        Debug.Log("ran");
        SceneManager.LoadScene("MainMenu");
    }

    //goToExit leaves the game when you click the exit button
    public void goToExit()

    {
        Debug.Log("ran");
        Application.Quit();
    }
}
