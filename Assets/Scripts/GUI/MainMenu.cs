using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject LoginMenu;
    public GameObject CharacterSelection;
    public GameObject CreateNewChar;

    private void Start()
    {
        //First panel is active at start
        StartMenu.SetActive(true);
    }
    public void Play()
    {
        //Once button pressed then
        //StartMenu is false
        StartMenu.SetActive(false);
        //LoginMenu is true
        LoginMenu.SetActive(true);
    }


    public void Login()
    {
        //If successful then...
        //Allow login   
        //otherwise
        //Create new character

        //Move to character custom
        LoginMenu.SetActive(false);
        CharacterSelection.SetActive(true);
    }

    public void CharSelect()
    {
        //Once Character is selected then...
            //Load Game
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
