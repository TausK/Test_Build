using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class OptiondManager : MonoBehaviour
{
    #region Variables
    [Header("Resolutuion")]
    //Vector2 array for resolution
    public Vector2[] res = new Vector2[4];
    public int resIndex;
    //resolution dropdown ui
    public Dropdown resDrop;

    //public AudioSource audio;
    //public Light light;
    //public Slider volSlide, brightSlide;
    #endregion
    // Use this for initialization
    void Start()
    {
        //find gameobject with name/tag "Music" and component 
        //audio = GameObject.Find("Music").GetComponent<AudioSource>();
        //light = GameObject.Find("Directional Light").GetComponent<Light>();
    }

    public void Resolutions()
    {
        //index equal to dropdown values
        resIndex = resDrop.value;
        //Set resolution value functionality
        Screen.SetResolution((int)res[resIndex].x, (int)res[resIndex].y,FullScreenMode.FullScreenWindow);
    }


}
