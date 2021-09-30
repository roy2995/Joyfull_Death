using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class target_shair : MonoBehaviour
{
    [Header("NPC Settings")]
    private Transform shair_dest;
    public NavMeshAgent NPC;
    public int silla_escogida;
    public veryfy_shair ref_manager;
    public bool satifecho = false;

    private void Start()
    {
        NPC = GetComponent<NavMeshAgent>();
        
    }

    private void Update()
    {
        if (isInDestination() && satifecho == false)
        {
            //se va desde que llega
            //ref_manager.shairs_ocuped[silla_escogida] = false;
            NPC.SetDestination(new Vector3(0, 0, 0));
            satifecho = true;
        }
    }

    public void Go_shair()
    {
        /* if(free.position == position_shair.position)
         {
             bool itsfree = free.GetComponent<veryfy_shair>();
             if (itsfree == true)
             {
                 NPC.SetDestination(position_shair.position);
             }
             else
             {
                 arrayshair.oderdestination = true;
             }*/
    }

    public bool isInDestination()
    {
        if (!NPC.pathPending)
        {
            if (NPC.remainingDistance <= NPC.stoppingDistance)
            {
                if (!NPC.hasPath || NPC.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }

        return false;
    }

}