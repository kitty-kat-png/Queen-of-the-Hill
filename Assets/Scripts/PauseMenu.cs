using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isGamePaused = false;
    public GameObject pauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused == false)
            {
                PauseGame();
            }
            else if (isGamePaused == true)
            {
                UnPauseGame();
            }
        }
    }
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Game paused");
        isGamePaused = true;
    }

    public void UnPauseGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("Game unpaused");
        isGamePaused = false;
    }
}
