using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Random_Nav : MonoBehaviour
{
    #region Variables
    public NavMeshAgent agent;
    public Transform waypointParent;
    public Transform[] waypoints;
    public float waypointDis;
    private float playerDis;
    private int index;
    public float delay = 2f;
    #endregion

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
        Patrol();
    }

    void Patrol()
    {
        //Enemy transform will equal to the waypoint array
        Transform point = waypoints[index];
        //player distance is equal to the vector distance from original position to new position
        playerDis = Vector3.Distance(transform.position, point.position);
        //if player distance is close to waypoint then..
        if (playerDis <= waypointDis)
        {
            StartCoroutine(DelayMovement());  
        }
       

        //Generate path to waypoints
        agent.SetDestination(point.position);
    }

    IEnumerator DelayMovement()
    {
        yield return new WaitForSeconds(delay);
        //Set new random waypoint
        index = Random.Range(1, waypoints.Length);
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
