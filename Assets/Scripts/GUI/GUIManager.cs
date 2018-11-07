using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    #region Menu 
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
    //Character Selection Menu
    public GameObject charSelect;
    //Character Creating Menu
    public GameObject createChar;
    #endregion

    #region
    public bool isMain;
    public bool iscCurMenu;
    
    //public int index;

    //public GameObject[] menus;

    #endregion


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

        if(!mainMenu.activeSelf)
        {
            isMain = false;
           
        }

        if (mainMenu.activeSelf)
        {
            isMain = true;
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



    public void Back()
    {
        login.SetActive(false);
        options.SetActive(false);
        createUser.SetActive(false);
        createChar.SetActive(false);


        //if the button is pressed then....
        //Toggle back to previous panel
        mainMenu.SetActive(true);
    }

    public void ExitBtn()
    {
        //Close application within editor mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        //Close Application
        Application.Quit();
    }
}
