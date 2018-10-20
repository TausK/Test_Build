using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    //Camera target
    public Transform target;
    //smooth transisiton
    public float smooth;
    //distance between camera & target
    public Vector3 offset;


    // Update is called once per frame
    void LateUpdate()
    {
        //Set position of camera offset on target
        Vector3 camPosition = target.position + offset;
        //Lerp camera to target
        Vector3 camSmooth = Vector3.Lerp(transform.position, camPosition, smooth);
        transform.position = camSmooth;
    }
}
