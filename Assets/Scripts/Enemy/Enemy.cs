using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;

public class Enemy : EnemyController
{
    private Rigidbody rb;

    private PlayerAttack playerAttack;

    public GameObject enemyAttackZone;

    private void OnDrawGizmos()
    {
        
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = 100f;
    }

    private void Update()
    {
        Death();
    }

    void Death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerAttackZone")
        {
            health -= playerAttack.dmg;
        }
    }
}
