using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : EnemyController
{


    public Slider bossHp;
    public float detectRadius;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
        //Vector3 direction = transform.TransformDirection(Vector3.forward) * attackRange;
        //Gizmos.DrawRay(attackPos.position, direction);
    }

    private void Start()
    {
        bossHp.maxValue = health;
        bossHp.value = health;
    }

    private void LateUpdate()
    {
        if (bossHp.value != health)
        {
            bossHp.value = health;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Reference player gameobject with tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //enemy dis to player dis
        float target = Vector3.Distance(transform.position, player.transform.position);
        if (target < detectRadius)
        {
            bossHp.enabled = true;

        }
    }
}
