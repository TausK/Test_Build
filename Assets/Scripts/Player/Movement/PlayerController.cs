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
            if(anim.GetBool("isMoving")!= true)
            {
                anim.SetBool("isMoving",true);
            }
        }

        //Running
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition(transform.position + input * maxSpeed * Time.deltaTime);
        }
        else
        {
            rb.MovePosition(transform.position + input * normSpeed * Time.deltaTime);
        }

        //if no input then...
        if (!Input.anyKey)
        {
            //Set moveposition to 0
            rb.MovePosition(transform.position + input * 0 * Time.deltaTime);
            if (anim.GetBool("isMoving") != false)
            {
                anim.SetBool("isMoving", false);
            }
        }

        

    }

   
    //void CollisionDetection()
    //{
    //    Ray ray = new Ray(transform.position, transform.forward);
    //    RaycastHit hit;
    //    if (Physics.SphereCast(ray, rayRadius, out hit))
    //    {
    //        if(hit.collider.tag == "Wall")
    //        {
    //            input = Vector3.zero;
    //        }
    //    }
    //}

}
