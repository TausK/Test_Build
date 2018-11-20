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
    public Transform target;
    public float detectRadius;
    public bool targetDetected;
    #endregion

    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward);
        //Gizmos.DrawRay(transform.position, direction);
        Gizmos.DrawRay(transform.position, direction* enemyDis);
    }

    private void Start()
    {
        //Grab navmesh component
        agent = GetComponent<NavMeshAgent>();
        //Grab transforms of each waypoint in waypoint parent
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        //set index to 1
        index = 1;

        targetDetected = false;
    }

    private void Update()
    {
        //Update patrol per frame
        Patrol();
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
        
    }

    #region Some other AI
    //private NavMeshAgent nav;
    //private Vector3 startPosition;
    //public float roamRadius;

    //void Awake()
    //{
    //    startPosition = transform.position;
    //    nav = GetComponent<NavMeshAgent>();
    //}

    //private void Start()
    //{
    //    FreeRoam();
    //}

    //void FreeRoam()
    //{
    //    Vector3 randomDir = transform.position + Random.insideUnitSphere * roamRadius;
    //    randomDir += startPosition;
    //    NavMeshHit hit;
    //    if (NavMesh.SamplePosition(randomDir, out hit, roamRadius, 1))
    //    {
    //        Vector3 finalPosition = hit.position;
    //        nav.destination = finalPosition;
    //    }
    //}
    #endregion
}
