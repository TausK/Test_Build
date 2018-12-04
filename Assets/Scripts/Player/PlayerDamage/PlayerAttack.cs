using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //time delay
    public float dmg = 15f;
    public float delay = 0.5f;
    
    private void OnEnable()
    {
        //Start attack sequance
        StartCoroutine(MeleeAttack());
    }

    IEnumerator MeleeAttack()
    {
        //Set a numerator delay
        yield return new WaitForSeconds(delay);
        //gameobject active false after delay
        gameObject.SetActive(false);       
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Norm.Enemy_Norm enemy = other.GetComponent<Norm.Enemy_Norm>();
        Boss.Enemy_Boss enemyBoss = other.GetComponent<Boss.Enemy_Boss>();
        if (enemy)
        {
            enemy.curHealth -= dmg;
        }
        if (enemyBoss)
        {
            enemyBoss.curHealth -= dmg;
        }
    }


}
