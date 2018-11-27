using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public PlayerController controller;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    private void Update()
    {
        if (controller.gameOver == true)
        {
            gameOverMenu.SetActive(true);   
        }


        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void RetryGame(int loadLvl)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(loadLvl);
    }

    public void ExitGame(int loadLvl)
    {
        SceneManager.LoadScene(loadLvl);
    }
}
