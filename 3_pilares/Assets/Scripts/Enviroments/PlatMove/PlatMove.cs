using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatMove : MonoBehaviour
{
    [Header("Plat_move Settings")]
    public GameObject platform;
    public Transform start;
    public Transform end;
    public float speed;
    private Vector3 moveTo;

    private void Start()
    {
        moveTo = end.position;
    }

    private void FixedUpdate()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, moveTo, speed * Time.deltaTime);

        if(platform.transform.position == end.position)
        {
            moveTo = start.position;
        }
        else if (platform.transform.position == start.position)
        {
            moveTo = end.position;
        }
    }
}
