using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void goToSettings()
    {
        Debug.Log("ran");
        SceneManager.LoadScene("Settings");
    }

    public void goToPlay()
    {
        Debug.Log("ran");
        SceneManager.LoadScene("Play");
    }

    public void goToMainMenu()
    {
        Debug.Log("ran");
        SceneManager.LoadScene("MainMenu");
    }

    public void goToExit()

    {
        Debug.Log("ran");
        Application.Quit();
    }
}
