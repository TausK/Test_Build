using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndGame : MonoBehaviour
{

    public GameObject chest;
   
    public int count;


    void Update()
    {
        if (count == 3)
        {
            chest.SetActive(true);
        }
    }

}
