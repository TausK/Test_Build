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
    //Login Menu
    public GameObject login;
    //Create user menu
    public GameObject createUser;
    //Forgot Pass
    public GameObject forgotPass;
    //Character Selection Menu
    public GameObject charSelect;
    //Character Creating Menu
    public GameObject createChar;
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
        mainMenu.SetActive(false);
        login.SetActive(true);
    }

    public void OptionBtn()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }
    #endregion

    #region Login Menu Functionality
    public void LoginGame()
    {
        login.SetActive(false);
        charSelect.SetActive(true);
    }

    public void CreateUserBtn()
    {
        login.SetActive(false);
        createUser.SetActive(true);
    }

    public void ForgotPassBtn()
    {
        login.SetActive(false);
        forgotPass.SetActive(true);
    }
    #endregion

    #region Back Functions
    public void OptionBack()
    {
        options.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void CreateUserBack()
    {
        createUser.SetActive(false);
        login.SetActive(true);
    }

    public void ForgotPassBack()
    {
        login.SetActive(true);
        forgotPass.SetActive(false);
    }

    public void LogOut()
    {
        login.SetActive(true);
        charSelect.SetActive(false);
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
