using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenWall : MonoBehaviour
{
    public int enemyCount;
    private void Start()
    {

    }
    private void Update()
    {
        foreach (var Gameobject in GameObject.FindGameObjectsWithTag("Boss"))
        {

        }

        if (enemyCount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
