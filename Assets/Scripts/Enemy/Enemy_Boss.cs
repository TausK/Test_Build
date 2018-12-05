using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;

namespace Boss
{

    public class Enemy_Boss : MonoBehaviour
    {
        private Rigidbody rb;

        public PlayerAttack playerAttack;

        public Random_Nav_Boss enemy;

        public EndGame game;
        public OpenWall open;
        public float health;
        public float curHealth;

        private void Start()
        {
            enemy = GetComponent<Random_Nav_Boss>();
            rb = GetComponent<Rigidbody>();

            curHealth = health;
            enemy.bossHp.maxValue = health;
            enemy.bossHp.value = curHealth;

            open = GameObject.FindGameObjectWithTag("Wall").GetComponent<OpenWall>();
            game = GameObject.FindGameObjectWithTag("Manager").GetComponent<EndGame>();
           
        }

        private void LateUpdate()
        {
            if (enemy.bossHp.value != curHealth)
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
                game.count++;
                open.enemyCount++;
                Destroy(gameObject);
                enemy.bossSlider.SetActive(false);
                
            }
        }
    }
}
