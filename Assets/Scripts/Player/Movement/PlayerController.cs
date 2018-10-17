using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    //player speed
    public float speed = 5f;
    private Vector3 input;
    //Rigidboys component;
    private Rigidbody rb;

    //Layermask for ground
    public LayerMask groundLayer;

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

        if(input != Vector3.zero)
        {
            rb.isKinematic = false;
            rb.MovePosition(transform.position + input * speed * Time.deltaTime);
        }
        else if(input != Vector3.zero && Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.MovePosition(transform.position + input * speed * Time.deltaTime);
        }

        

        if (!Input.anyKey)
        {
            rb.MovePosition(transform.position + input * 0 * Time.deltaTime);
        }

    }

   
}
