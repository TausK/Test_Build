using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour
{
    public Transform target;
    public Vector3 camPos = Vector3.zero;
    //public float distance = 3.0f;
    //public float height = 3.0f;
    public float damping = 5.0f;

    public bool followBehind = true;


    void FixedUpdate()
    {
        Vector3 wantedPosition;
        if (followBehind)
            wantedPosition = target.TransformPoint(camPos);
        else
            wantedPosition = target.position + camPos;

        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

    }
}