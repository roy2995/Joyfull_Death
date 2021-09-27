using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class target_shair : MonoBehaviour
{
    [Header("NPC Settings")]
    private Transform shair_dest;
    public Transform[] shairs_free;
    public NavMeshAgent NPC;
    private int count;

    private void Start()
    {
        NPC = GetComponent<NavMeshAgent>();
        count = shairs_free.Length;
    }

    private void Update()
    {
        //Go_shair(veryfy_shair);
    }

    public void Go_shair(Transform position_shair)
    {
        foreach(Transform free in shairs_free)
        {
            if(free.position == position_shair.position)
            {
                /*bool itsfree = free.GetComponent<veryfy_shair>();
                if (itsfree == true)
                {
                    NPC.SetDestination(position_shair.position);
                }
                else
                {
                    arrayshair.oderdestination = true;
                }*/
            }
        }
        

    }

}
