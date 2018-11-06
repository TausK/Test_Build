using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    #region Player Movement
    //Default speed
    public float defSpeed;
    //player speed
    public float normSpeed = 1.5f;
    //MaxSpeed
    public float maxSpeed = 2.5f;
    //Default input vector to 0
    private Vector3 input = Vector3.zero;
    //Rigidboys component;
    private Rigidbody rb;
    #endregion
    //public Animator anim;

    //Sword Object
    public GameObject melee;



    // Use this for initialization
    void Start()
    {
        //Reference rigid component on object
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MeleeAttack();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");

        //Vector3 euler = transform.eulerAngles;
        //euler.y = Mathf.Atan2(input.z, input.x) * Mathf.Rad2Deg;
        //transform.eulerAngles = euler;

        //Normal Input 
        if (input != Vector3.zero)
        {
            rb.velocity = input * normSpeed;
            rb.MoveRotation(Quaternion.LookRotation(input));
            //if(anim.GetBool("isMoving")!= true)
            //{
            //    anim.SetBool("isMoving", true);
            //}
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
            //if (anim.GetBool("isMoving") != false)
            //{
            //    anim.SetBool("isMoving", false);
            //}
        }

    }

    void MeleeAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            melee.SetActive(true);
        }
    }


}
