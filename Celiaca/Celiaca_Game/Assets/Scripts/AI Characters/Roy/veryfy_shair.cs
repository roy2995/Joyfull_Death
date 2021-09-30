using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class veryfy_shair : MonoBehaviour
{
    [Header("shairs")]
    public Transform[] chairs_free;
    public bool[] shairs_ocuped;
    private target_shair target_;
    Transform target;
    private void Start()
    {
        target_ = GetComponent<target_shair>();
        target_.ref_manager = GetComponent<veryfy_shair>();
        if(shairs_ocuped[0] == false)
        {
            target_.silla_escogida = 0;
            target_.NPC.SetDestination(chairs_free[0].position);
        }

    }

    private void Update()
    {

    }

    public Transform free()
    {
        target = chairs_free[Random.Range(0, chairs_free.Length)];

        return target;
    }
}
