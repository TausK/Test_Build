using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEnd : MonoBehaviour
{
    public float timer = 5;
    public float scenTimer;
 
    // Update is called once per frame
    void Update()
    {
        scenTimer += Time.deltaTime;
        if(scenTimer >= timer)
        {
            scenTimer = 0;
            Debug.Log("times up");
            SceneManager.LoadScene(2);
        }
    }
}
