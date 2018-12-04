using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;

namespace Norm
{

    public class Enemy_Norm : MonoBehaviour
    {
        private Rigidbody rb;

        public PlayerAttack playerAttack;

        public float health;
        public float curHealth;

        public OpenWall open;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();

            curHealth = health;

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
            }
        }
    }
}
