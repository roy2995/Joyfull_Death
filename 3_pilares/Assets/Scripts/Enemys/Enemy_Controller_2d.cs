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
    public float x;
    public float y;

    private void Awake()
    {
        pat_faceDirection = pat_Right;
        Base_Scale = transform.localScale;
        Enemy_rig = GetComponent<Rigidbody2D>();
    }





    public void Enemy_Patrol()
    {
        float vx = patrolMoveSpeed;
        if(pat_faceDirection == pat_Left)
        {
            vx = -patrolMoveSpeed;
        }

        Enemy_rig.velocity = new Vector2(vx, Enemy_rig.velocity.y);

    }

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

    }









}
