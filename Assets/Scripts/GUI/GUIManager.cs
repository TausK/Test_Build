using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Options;
    public GameObject Login;
    public GameObject CreateUser;
    public GameObject CharSelect;
    public GameObject CreateChar;

  
    
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
