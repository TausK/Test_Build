using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="EnemyController", menuName = "Enemy Controller", order =51)]
public class EnemyController : ScriptableObject
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float health;
   
    private Rigidbody rb;

   

}
