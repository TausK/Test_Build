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
        EnemyController enemy = other.GetComponent<EnemyController>();
        if (enemy)
        {
            enemy.curHealth -= dmg;
        }
    }


}
