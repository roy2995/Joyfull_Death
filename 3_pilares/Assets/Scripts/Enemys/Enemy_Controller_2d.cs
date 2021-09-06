using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller_2d : MonoBehaviour
{
    [Header("Objects Manager")]
    //Golbal
    Rigidbody2D Enemy_rig;
    //patrol objects
    public Transform Cast_post;
    //detection objects
    public Transform Player;

    [Header("Enemy_Patrol Settings")]
    [Range(0, 10)] public float patrolMoveSpeed;
    [Range(0, 10)] public float base_cast_dist;
    Vector3 Base_Scale;
    string pat_faceDirection;
    const string pat_Left = "Left";
    const string pat_Right = "right";

    [Header("Enemy_Detection Settings")]
    [Range(0, 20)] public float AgroRange;
    [Range(0, 10)] public float detecMoveSpeed;
    public bool detection = false;
    public float x;
    public float y;

    private void Awake()
    {
        pat_faceDirection = pat_Right;
        Base_Scale = transform.localScale;
        Enemy_rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Debug.Log(detection);
        float distance = Vector2.Distance(transform.position, Player.position);
        if (detection == false)
        {
            Enemy_Patrol();
        }
        
        if (distance < AgroRange)
        {
            detection = true;
            Enemy_Detection();
        }
        else
        {
            detection = false;
        }
    }

    public void Enemy_Detection()
    {
        float distances = Vector2.Distance(transform.position, Player.position);
        if (distances < AgroRange)
        {
            //chase player & stop patrol
            chase_player();  
        }
        else
        {
            //stop chase & continue patrol
            detection = false;
            stopchase();
        }
    }

    private void chase_player()
    {
        if(transform.position.x < Player.position.x)
        {
            Enemy_rig.velocity = new Vector2(detecMoveSpeed, 0);
            transform.localScale = new Vector2(x, y);
        }
        else if (transform.position.x > Player.position.x)
        {
            Enemy_rig.velocity = new Vector2(-detecMoveSpeed, 0);
            transform.localScale = new Vector2(-x, y);
        }
    }

    private void stopchase()
    {
        //Enemy_rig.velocity = new Vector2(0, 0);
        Debug.Log("stopchase detectado");
        detection = false;
    }


    public void Enemy_Patrol()
    {
        float vx = patrolMoveSpeed;
        if(pat_faceDirection == pat_Left)
        {
            vx = -patrolMoveSpeed;
        }

        Enemy_rig.velocity = new Vector2(vx, Enemy_rig.velocity.y);
        if(HitWall() || NearEdge())
        {
            if(pat_faceDirection == pat_Left)
            {
                changeDirection(pat_Right);
            }
            else if(pat_faceDirection == pat_Right)
            {
                changeDirection(pat_Left);
            }
        }

    }
    //patrol funcions
    private bool HitWall()
    {
        bool val = false;
        float castDist = base_cast_dist;
        if(pat_faceDirection == pat_Left)
        {
            castDist = -base_cast_dist;
        }
        else
        {
            castDist = base_cast_dist;
        }
        Vector3 targetpos = Cast_post.position;
        targetpos.x += castDist;
        Debug.DrawLine(Cast_post.position, targetpos, Color.cyan);
        if(Physics2D.Linecast(Cast_post.position, targetpos, 1 << LayerMask.NameToLayer("Terrain")))
        {
            val = true;
        }
        else
        {
            val = false;
        }
        return val;
    }

    private bool NearEdge()
    {
        bool val = true;

        float castDist = base_cast_dist;
        Vector3 targetpos = Cast_post.position;
        targetpos.y -= castDist;

        Debug.DrawLine(Cast_post.position, targetpos, Color.green);

        if (Physics2D.Linecast(Cast_post.position, targetpos, 1 << LayerMask.NameToLayer("Terrain")))
        {
            val = false;
        }
        else
        {
            val = true;
        }
        return val;
    }

    private void changeDirection(string newDirection)
    {
        Vector3 newScale = Base_Scale;

        if(newDirection == pat_Left)
        {
            newScale.x = -Base_Scale.x;
        }
        else if(newDirection == pat_Left)
        {
            newScale.x = Base_Scale.x;
        }
        transform.localScale = newScale;
        pat_faceDirection = newDirection;
    }
}
