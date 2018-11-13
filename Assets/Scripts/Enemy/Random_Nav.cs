using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Random_Nav : MonoBehaviour
{
    private NavMeshAgent nav;
    private Vector3 startPosition;
    public float roamRadius;

    void Awake()
    {
        startPosition = transform.position;
        nav = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        FreeRoam();
    }

    void FreeRoam()
    {
        Vector3 randomDir = transform.position + Random.insideUnitSphere * roamRadius;
        randomDir += startPosition;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDir, out hit, roamRadius, 1))
        {
            Vector3 finalPosition = hit.position;
            nav.destination = finalPosition;
        }
    }
}
