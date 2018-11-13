using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour
{
    public Vector3 camPos = Vector3.zero;

    #region Follow Player
    public Transform target;
    public float smoothness = 5.0f;
    private bool followPlayer;
    #endregion

    #region Camera World Collision
    public float boundX;
    public float boundY;
    #endregion

    void FixedUpdate()
    {
        CameraMovement();
    }

    void CameraMovement()
    {
        Vector3 wantedPosition;
        if (followPlayer)
        {
            wantedPosition = target.TransformPoint(camPos);
        }
        else
        {
            wantedPosition = target.position + camPos;
        }

        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * smoothness);


    }


}