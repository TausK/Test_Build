using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;

public class Enemy : EnemyController
{
    private Rigidbody rb;

    public PlayerAttack playerAttack;

    public Random_Nav enemy;

    private void Start()
    {
        enemy = GetComponent<Random_Nav>();
        rb = GetComponent<Rigidbody>();

        curHealth = health;
        enemy.bossHp.maxValue = health;
        enemy.bossHp.value = curHealth;
    }

    private void LateUpdate()
    {
        if(enemy.bossHp.value != curHealth)
        {
            enemy.bossHp.value = curHealth;
        }
    }
    
    private void Update()
    {
        Death();
    }

    void Death()
    {
        if (curHealth <= 0)
        {
            Destroy(gameObject);
            enemy.bossSlider.SetActive(false);
        }
    }
}
