using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            if(isGamePaused == false)
            {
                pauseGame();
            }
            else if(isGamePaused == true)
            {
                unPauseGame();
            }
        }
    }

    public void pauseGame()
    {
         SceneManager.LoadScene("PauseMenu");
         Debug.Log("Game paused");
         isGamePaused = true;
    }

    public void unPauseGame()
    {
         SceneManager.LoadScene("SampleScene");
         Debug.Log("Game unpaused");
         isGamePaused = false;
    }
}
