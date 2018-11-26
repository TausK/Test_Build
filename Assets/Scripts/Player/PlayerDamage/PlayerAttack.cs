using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //time delay
    public float dmg = 50f;
    public float delay = 0.5f;

    private void Start()
    {
        //Set gameobject active false at start
        gameObject.SetActive(false);
    }

    private void Update()
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

   
}
