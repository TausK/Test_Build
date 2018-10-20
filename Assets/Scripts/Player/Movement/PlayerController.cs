using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    //player speed
    public float normSpeed = 5f;
    //MaxSpeed
    public float maxSpeed = 7f;
    //Condition for running
    public bool isRun;
    private Vector3 input;
    //Rigidboys component;
    private Rigidbody rb;



    // Use this for initialization
    void Start()
    {
        //Reference rigid component on object
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        input = Vector3.zero;
        input.z = Input.GetAxis("Horizontal");
        input.x = Input.GetAxis("Vertical");
        //Normal Input 
        if (input != Vector3.zero)
        {
            rb.MovePosition(transform.position + input * normSpeed * Time.deltaTime);
        }

        //if no input then...
        if (!Input.anyKey)
        {
            //Set moveposition to 0
            rb.MovePosition(transform.position + input * 0 * Time.deltaTime);
        }

    }

}
