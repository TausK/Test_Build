//using System.Collections;
//using UnityEngine;
//using UnityEngine.SceneManagement;//interacting with scene change
//using UnityEngine.UI;//interacting with GUI elements
//using UnityEngine.EventSystems;//control the event (button shiz)
//[AddComponentMenu("Skyrim2.0/Menus/Main")]
//public class OptionsManager : MonoBehaviour
//{
//    #region Variables
//    [Header("OPTIONS")]
//    public Vector2[] res = new Vector2[7];
//    public int resIndex;
//    public bool isFullScreen;
//    [Header("References")]
//    public AudioSource mainAudio;
//    public Light dirLight;
//    public Dropdown resDropdown;
//    public Slider volSlider, brightSlider;

//    #endregion
//    void Start()
//    {
//        mainAudio = GameObject.Find("MainMusic").GetComponent<AudioSource>();
//        dirLight = GameObject.Find("Directional Light").GetComponent<Light>();

//    }
//    public void LoadGame()
//    {
//        SceneManager.LoadScene(1);
//    }
//    public void ExitGame()
//    {
//#if UNITY_EDITOR
//        UnityEditor.EditorApplication.isPlaying = false;
//#endif
//        Application.Quit();
//    }

//    {

//            volSlider = GameObject.Find("AudioSlider").GetComponent<Slider>();

//            brightSlider = GameObject.Find("BrightSlider").GetComponent<Slider>();

//            resDropdown = GameObject.Find("Resolution").GetComponent<Dropdown>();

//            volSlider.value = mainAudio.volume;
//            brightSlider.value = dirLight.intensity;

//            return true;
//        }
//    }
//    public void Volume()
//{
//    mainAudio.volume = volSlider.value;
//}
//public void Brightness()
//{
//    dirLight.intensity = brightSlider.value;
//}

//public void Resolution()
//{
//    resIndex = resDropdown.value;
//    Screen.SetResolution((int)res[resIndex].x, (int)res[resIndex].y, isFullScreen);
//}
//    //public void Save()
//    //{
//    //    PlayerPrefs.SetString("Forward", forward.ToString());
//    //    PlayerPrefs.SetString("Backward", backward.ToString());
//    //    PlayerPrefs.SetString("Left", left.ToString());
//    //    PlayerPrefs.SetString("Right", right.ToString());
//    //    PlayerPrefs.SetString("Jump", jump.ToString());
//    //    PlayerPrefs.SetString("Crouch", crouch.ToString());
//    //    PlayerPrefs.SetString("Sprint", sprint.ToString());
//    //    PlayerPrefs.SetString("Interact", interact.ToString());
//    //}

//}
