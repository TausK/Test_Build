using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenWall : MonoBehaviour
{
    public int enemyCount;
   
    private void Update()
    {
        

        if (enemyCount == 2)
        {
            Destroy(gameObject);
        }
    }
}
