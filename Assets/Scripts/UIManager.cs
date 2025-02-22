using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void StartGame() //Starts game
    {
        SceneManager.LoadScene("Game"); //switch this to whatever the main game scene is named
        Debug.Log("Starting game");
    }

    public void QuitGame() //Quits application
    {
        Application.Quit();
        Debug.Log("Quitting application");
    }

    public void openSettings()
    {
        SceneManager.LoadScene("SettingsScene");
        Debug.Log("Opening settings");
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Returning to main menu");
    }
}
