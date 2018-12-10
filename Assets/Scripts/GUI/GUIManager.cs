using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    #region Variables
    [Header("Menu Gameobjects")]
    #region Menu Gameobjects
    //Beginning of menu
    public GameObject startMenu;
    //GUI Pop up in main menu
    public GameObject startMenuGUI;
    //Main Menu
    public GameObject mainMenu;
    //Options Menu
    public GameObject options;
    #endregion
    #endregion

    #region Main Menu Functionality
    private void Start()
    {
        startMenu.SetActive(true);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            startMenu.SetActive(false);
            startMenuGUI.SetActive(true);
            return;
        }

    }


    public void PlayBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        mainMenu.SetActive(false);
        //login.SetActive(true);
    }

    public void OptionBtn()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }
    #endregion

   

    #region Back Functions
    public void OptionBack()
    {
        options.SetActive(false);
        mainMenu.SetActive(true);
    }
    #endregion

    public void ExitBtn()
    {
        //Close application within editor mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        //Close Application
        Application.Quit();
    }

    public void StartOffline(int loadLevel)
    {
        SceneManager.LoadScene(loadLevel);
    }
}
