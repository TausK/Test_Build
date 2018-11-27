using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float dmg = 20f;
    public float delay = 0.5f, timer;
    public bool hasAttacked;
    // Use this for initialization
    void Start()
    {
        //Deactivate attackzone at start
    }

    // Update is called once per frame
    void Update()
    {
        if (hasAttacked)
        {
            timer += Time.deltaTime;
        }
        if(timer > delay)
        {
            hasAttacked = false;
            timer = 0;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(!hasAttacked)
        {
            if (other.CompareTag("Player"))
            {
                if(other.GetComponent<PlayerController>().gameOver == false)
                {
                    other.GetComponent<PlayerController>().curHealth -= dmg;
                    hasAttacked = true;
                }               

            }
        }
        
    }


}
