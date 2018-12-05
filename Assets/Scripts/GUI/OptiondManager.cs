using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//Saving to computer via input + output
using System.IO;

[System.Serializable]
public class OptionData
{
    public int resIndex;
}

public class OptiondManager : MonoBehaviour
{
    #region Variables
    [Header("Resolutuion")]
    //Vector2 array for resolution
    public Vector2[] res = new Vector2[4];
    public int resIndex;
    //resolution dropdown ui
    public Dropdown resDrop;
    public Toggle tog;
    //public AudioSource audio;
    //public Light light;
    //public Slider volSlide, brightSlide;
    #endregion

    #region Game Save Data
    //Reference to Game Data class
    public OptionData data = new OptionData();
    //Set file string name
    public string fileName = "GameData";
    #endregion

   
    public bool low; //public boolean for low quality
    public bool med; //public boolean for medium quality
    public bool high; //public boolean for high quality
    public float volume; //public float for game volume



    private void Awake()
    {
        LoadData();
        Screen.fullScreen = false;
    }
    // Use this for initialization
    void Start()
    {
        //find gameobject with name/tag "Music" and component 
        //audio = GameObject.Find("Music").GetComponent<AudioSource>();
        //light = GameObject.Find("Directional Light").GetComponent<Light>();
    }
    public void SaveData()
    {
        data.resIndex = resIndex;

        //Set file save pathway
        string filePath = Application.dataPath + "/Data/" + fileName + ".json";
        //Set .json format
        string json = JsonUtility.ToJson(data);
        //File name save as fileName path + json format
        File.WriteAllText(filePath, json);

        Debug.Log("Save Data :" + filePath);

    }

    public void LoadData()
    {
        //Set file save pathway
        string filePath = Application.dataPath + "/Data/" + fileName + ".json";
        //Set .json format
        string json = File.ReadAllText(filePath);
        //File From json format
        data = JsonUtility.FromJson<OptionData>(json);

        //Load data
        data.resIndex = resIndex;
        Debug.Log("Load Data :" + filePath);
    }

    public void Resolutions()
    {
        //index equal to dropdown values
        resIndex = resDrop.value;
        Vector2 resolution = res[resIndex];
        //Set resolution value functionality
        Screen.SetResolution((int)resolution.x, (int)resolution.y, Screen.fullScreen);
    }

    public void FullscreenToggle()
    {
        if (!tog.isOn)
        {
            Screen.fullScreen = false;
          
        }
        if(tog.isOn)
        {
            Screen.fullScreen = true;
           
        }
        
    }

}
