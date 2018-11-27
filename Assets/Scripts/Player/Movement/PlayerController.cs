﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]

    #region Player Movement
    //Default speed
    public float defSpeed;
    //player speed
    public float normSpeed = 1.5f;
    //MaxSpeed
    public float maxSpeed = 2.5f;

    public float gravity = 20;
    //Default input vector to 0
    private Vector3 input = Vector3.zero;
    //Rigidboys component;
    private Rigidbody rb;
    #endregion

    public Animator anim;

    //Sword Object
    public GameObject melee;
    public EnemyAttack enemyAttack;

    public Slider hpSlide;
    public float health = 100;
    public float curHealth;

    public bool gameOver;
    public Image fill;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        //Reference rigid component on object
        rb = GetComponent<Rigidbody>();
        curHealth = health;
        hpSlide.maxValue = health;
        hpSlide.value = curHealth;
    }

    private void Update()
    {
        MeleeAttack();
        Death();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
    }
    private void LateUpdate()
    {
        if(hpSlide.value != curHealth)
        {
            hpSlide.value = curHealth;
        }
    }
    void PlayerMovement()
    {
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");

        //Normal Input 
        if (input != Vector3.zero)
        {
            anim.SetBool("isWalking", true);
            rb.velocity = input.normalized * normSpeed;
            rb.MoveRotation(Quaternion.LookRotation(input));
          
        }
        else
        {
            anim.SetBool("isWalking", false);
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

        rb.AddForce(Vector3.down * gravity);
    }
   
    void MeleeAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            melee.SetActive(true);
            anim.SetBool("isAttacking", true);

            //anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }




    void Death()
    {
        if(curHealth <= 0)
        {
            gameOver = true;
            Time.timeScale = 0;
            fill.transform.gameObject.SetActive(false);
        }
    }
}
