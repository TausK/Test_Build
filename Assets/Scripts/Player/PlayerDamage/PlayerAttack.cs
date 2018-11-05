using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Collider col;
    public bool attack;
    // Use this for initialization
    void Start()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
    }

    private void Update()
    {
        if (attack)
        {
            col.enabled = true;
        }


    }

}
