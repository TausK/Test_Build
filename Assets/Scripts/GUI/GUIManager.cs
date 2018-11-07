using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    #region Menu 
    //Beginning of menu
    public GameObject StartMenu;
    //Main Menu
    public GameObject MainMenu;
    //Options Menu
    public GameObject Options;
    //Login Menu
    public GameObject Login;
    //Create user menu
    public GameObject CreateUser;
    //Character Selection Menu
    public GameObject CharSelect;
    //Character Creating Menu
    public GameObject CreateChar;
    #endregion


    private void Start()
    {
        StartMenu.SetActive(true);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            StartMenu.SetActive(false);
            MainMenu.SetActive(true);
        }  
    }

    public void PlayBtn()
    {

    }


    public void Back()
    {
        //if the button is pressed then....
            //Toggle back to previous panel
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
