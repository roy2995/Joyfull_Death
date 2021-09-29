using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class veryfy_shair : MonoBehaviour
{
    [Header("shairs")]
    public Transform[] chairs_free;
    public BoxCollider[] shairs_ocuped;
    private target_shair target_;
    Transform target;
    private void Start()
    {
        target_ = GetComponent<target_shair>();
    }

    private void Update()
    {
        target_.Go_shair(free());
    }

    public Transform free()
    {
        target = chairs_free[Random.Range(0, chairs_free.Length)];

        return target;
    }
}
