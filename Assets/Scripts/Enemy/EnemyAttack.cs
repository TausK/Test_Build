using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float dmg = 20f;
    public float delay = 0.5f;
    
    // Use this for initialization
    void Start()
    {
        //Deactivate attackzone at start
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MeleeAttack());
    }

    IEnumerator MeleeAttack()
    {
        //Set delay
        yield return new WaitForSeconds(delay);
        //deactivate gameobject
        gameObject.SetActive(false);
    }


}
