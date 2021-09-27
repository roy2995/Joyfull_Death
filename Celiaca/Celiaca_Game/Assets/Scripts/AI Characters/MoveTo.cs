using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

    //No tiene mucha ciencia explicar pero lo que hace es solo mover al navmesh agent al punto que quiero.

    public Transform Destination;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(Destination.position);
    }

}
