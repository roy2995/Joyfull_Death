using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_patrol : MonoBehaviour
{
    [Header("Move Settings")]
    Rigidbody2D enemy_rig;
    public float moveSpeed = 5f;

    [Header("Patrol AI settings")]
    public Transform CastPost;
    public Transform viwpoint;
    public float baseCastDist;
    Vector3 basescale;
    string faceDirection;
    const string Left = "left";
    const string Right = "right";

    private void Start()
    {
        faceDirection = Right;
        basescale = transform.localScale;
        enemy_rig = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float vx = moveSpeed;
        if(faceDirection == Left)
        {
            vx = -moveSpeed;
        }
        enemy_rig.velocity = new Vector2(vx, enemy_rig.velocity.y);
        if (HitWall() || NearEdge())
        {
            if (faceDirection == Left)
            {
                changedirect(Right);
            }
            else if (faceDirection == Right)
            {
                changedirect(Left);
            }
        }
    }

    void changedirect(string newDirection)
    {
        Vector3 newScale = basescale;

        if(newDirection == Left)
        {
            newScale.x = -basescale.x;
        }
        else if(newDirection == Right)
        {
            newScale.x = basescale.x;
        }

        transform.localScale = newScale;
        viwpoint.localScale = newScale;
        faceDirection = newDirection;
    }

    bool HitWall()
    {
        bool val = false;

        float castDist = baseCastDist;
        if(faceDirection == Left)
        {
            castDist = -baseCastDist;
        }
        else
        {
            castDist = baseCastDist;
        }

        Vector3 tragetpos = CastPost.position;
        tragetpos.x += castDist;

        Debug.DrawLine(CastPost.position, tragetpos, Color.red);

        if (Physics2D.Linecast(CastPost.position, tragetpos, 1 << LayerMask.NameToLayer("Terrain")))
        {
            val = true;
        }
        else
        {
            val = false;
        }

        return val;
    }

    bool NearEdge()
    {
        bool val = true;

        float castDist = baseCastDist;

        Vector3 tragetpos = CastPost.position;
        tragetpos.y -= castDist;

        Debug.DrawLine(CastPost.position, tragetpos, Color.blue);

        if (Physics2D.Linecast(CastPost.position, tragetpos, 1 << LayerMask.NameToLayer("Terrain")))
        {
            val = false;
        }
        else
        {
            val = true;
        }

        return val;
    }



}
