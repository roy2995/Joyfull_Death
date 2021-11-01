using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{

    public Rigidbody[] balls;
    private Rigidbody lastRedgeSet;
    public Rigidbody FixedRedgeSet;
    public float speed = 20f;

    private int Counter_Attemps = 0;
    public bool _spaceIsPressed;

    private Transform transformObj;

    void Start()
    {
        lastRedgeSet = FixedRedgeSet;
        _spaceIsPressed = false;
    }

    void Update()
    {
        Vector3 LastRedgeSetPos = lastRedgeSet.transform.position;
        //////////////////////////////////////////////////////////
        if(Input.GetKey(KeyCode.Space))
        {
            Invoke("BodyLaunch", 10f);
            BodyLaunch();
        }

        if(_spaceIsPressed)
        {
            for (int i = 0; i >= 0; i++)
            {
                i = Counter_Attemps;
                Counter_Attemps++;
                Debug.Log(Counter_Attemps);
            }
        }
    }

    void BodyLaunch()
    {
        Rigidbody ballClone = (Rigidbody)Instantiate(balls[UnityEngine.Random.Range(0, 1)], transform.position, transform.rotation);
        ballClone.velocity = transform.forward * speed;

        Transform t = ballClone.transform;
        t.parent = transformObj;
        transformObj = t;

        /*Rigidbody ballClone = (Rigidbody)Instantiate(balls, transform.position, transform.rotation);
        ballClone.velocity = transform.forward * speed;*/
    }
}
