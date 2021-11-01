using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballspawn : MonoBehaviour
{
    [Header("Spawn Settings")]
    private int max_balls = 5;
    private int coun_balls;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject spawner;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && coun_balls <=4 )
        {
            StartCoroutine(spawn());
        }
        else
        {
            StopCoroutine(spawn());
        }


    }

    IEnumerator spawn()
    {
        Instantiate(ball, spawner.transform.position, Quaternion.identity);
        coun_balls += 1;
        yield return new WaitForSecondsRealtime(1f);
    }







}
