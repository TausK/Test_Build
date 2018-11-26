using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Random_Nav : MonoBehaviour
{
    #region Variables
    #region Random AI Seek
    public NavMeshAgent agent;

    public Transform waypointParent;
    public Transform[] waypoints;
    public float waypointDis;
    private float enemyDis;
    private int index;
    public float delay = 2f;
    #endregion

    #region AI Movement Timer
    public bool stopMove;
    public float counter = 0;
    public float patrolTimer = 2;
    #endregion

    #region Enemy Target Seek
    public float detectRadius = 1f;
    public float attackRange = 0.5f;
    public string playerTag = "Player";
    public GameObject attackZone;

    #endregion

    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
        Vector3 direction = transform.TransformDirection(Vector3.forward) * attackRange;
        Gizmos.DrawRay(transform.position, direction);
    }

    private void Start()
    {
        //Grab navmesh component
        agent = GetComponent<NavMeshAgent>();
        //Grab transforms of each waypoint in waypoint parent
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        //set index to 1
        index = 1;


    }

    private void Update()
    {
        //Update patrol per frame
        Patrol();
        PlayerDetect();
    }

    void Patrol()
    {
        //target transform will equal to the waypoint array
        Transform point = waypoints[index];
        //player distance is equal to the vector distance from original position to new position
        enemyDis = Vector3.Distance(transform.position, point.position);
        //if player distance is close to waypoint then..
        agent.SetDestination(point.position);
        //if enemys distance is less then current waypoint position then..
        if (enemyDis <= waypointDis)
        {
            //stop player movement false
            stopMove = true;
            //ai destination is the current transform of currrent waypoint
            agent.SetDestination(this.transform.position);
        }
        //if stopMove is true then...
        if (stopMove)
        {
            //Start counter
            counter += Time.deltaTime;
            //if counter is bigger or equal to patrolTimer(Delay) then....
            if (counter >= patrolTimer)
            {
                //Set random waypoint point in array
                index = Random.Range(1, waypoints.Length);
                //stop move is false
                stopMove = false;
                //counter reset
                counter = 0;
                //Ai destination is new point set
                agent.SetDestination(point.position);
            }
        }
    }

    void PlayerDetect()
    {
        //Reference player gameobject with tag
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        //enemy dis to player dis
        float target = Vector3.Distance(transform.position, player.transform.position);
        if(target < detectRadius)
        {
            agent.SetDestination(player.transform.position);

            if(target <= attackRange)
            {
                attackZone.SetActive(true);
                agent.speed = 0;
            }
            else
            {
                agent.speed = 0.3f;
            }
            
            
        }
    }

}
