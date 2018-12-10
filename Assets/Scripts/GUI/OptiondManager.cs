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
    public AudioSource audio;
    //public Slider volSlide;
    public float volSet = 1;
    #endregion

    #region Game Save Data
    //Reference to Game Data class
    public OptionData data = new OptionData();
    //Set file string name
    public string fileName = "GameData";
    #endregion


    public Toggle low; //public boolean for low quality
    public Toggle med; //public boolean for medium quality
    public Toggle high; //public boolean for high quality
    public float volume; //public float for game volume

    public bool _low;
    public bool _med;
    public bool _high;

    private void Awake()
    {
        LoadData();
        Screen.fullScreen = false;
    }
    // Use this for initialization
    void Start()
    {
        low.isOn = false;
        med.isOn = true;
        high.isOn = false;
        //find gameobject with name/tag "Music" and component 
        //audio = GameObject.Find("Music").GetComponent<AudioSource>();
        //light = GameObject.Find("Directional Light").GetComponent<Light>();
    }

    private void Update()
    {
        audio.volume = volSet;
    }

    public void SetVolume(float vol)
    {
        volSet = vol;
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
        if (tog.isOn)
        {
            Screen.fullScreen = true;

        }

    }
    #region LowGraphics
    public void LowGraphicalQuality()
    {
        if (low.isOn == true)
        {
            //QualitySettings.masterTextureLimit = 2;
            QualitySettings.SetQualityLevel(1); //Set the quality level to 1
            med.isOn = false; //Medium is set to false
            high.isOn = false; //High is set to false
            _high = false; //gameSettings high is set to false
            _med = false; //gameSettings medium is set to false
            _low = true; //gameSettings low is set to true
        }
    }
    #endregion
    #region MediumGraphics
    public void MedGraphicalQuality()
    {

        if (med.isOn == true)
        {
            //QualitySettings.masterTextureLimit = 1;
            QualitySettings.SetQualityLevel(2);  //Set the quality level to 2
            low.isOn = false; //low is set to false
            high.isOn = false; //High is set to false
            _high = false; //gameSettings high is set to false
            _med = true; //gameSettings medium is set to true
            _low = false; //gameSettings low is set to false
        }
    }
    #endregion
    #region HighGraphics
    public void HighGraphicalQuality()
    {
        if (high.isOn == true)
        {
            //QualitySettings.masterTextureLimit = 0;
            QualitySettings.SetQualityLevel(3); //Set the quality level to 3
            med.isOn = false; //Medium is set to false
            low.isOn = false; //Low is set to false
            _high = true; //gameSettings high is set to true
            _med = false; //gameSettings medium is set to false
            _low = false; //gameSettings low is set to false
        }
    }
    #endregion

    
}
