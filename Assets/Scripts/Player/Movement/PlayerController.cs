using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    //Default speed
    public float defSpeed;
    //player speed
    public float normSpeed = 1.5f;
    //MaxSpeed
    public float maxSpeed = 2.5f;

    private Vector3 input;
    //Rigidboys component;
    private Rigidbody rb;

    public float rayRadius;

    public Animator anim;

    //Sword Object
    public GameObject sword;

    // Use this for initialization
    void Start()
    {
        //Reference rigid component on object
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        input = Vector3.zero;
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");
        
        Vector3 euler = transform.eulerAngles;
        euler.y = Mathf.Atan2(input.z, input.x) * Mathf.Rad2Deg;
        transform.eulerAngles = euler;

        //Normal Input 
        if (input != Vector3.zero)
        {
            rb.velocity = input * normSpeed;

            if(anim.GetBool("isMoving")!= true)
            {
                anim.SetBool("isMoving", true);
            }
        }

        //Running
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = input * maxSpeed;
        }
        else
        {
            rb.velocity = input * normSpeed;
        }

        //if no input then...
        if (!Input.anyKey)
        {
            //Set moveposition to 0
            //rb.MovePosition(rb.position + input * 0 * Time.deltaTime);
            if (anim.GetBool("isMoving") != false)
            {
                anim.SetBool("isMoving", false);
            }
        }

        

    }
    

}
