using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Detection : MonoBehaviour
{
    [Header("Enemiy Detection")]
    public Component patrol_mode;
    public Transform castPoint;
    public Transform player;
    public float AgroRange;
    public float moveSpeed;
    bool IsAgro = false;
    private bool issearching;
    bool facing_enemy;
    Rigidbody2D enemy_rig;

    [Header("Scale Settings")]
    public float x;
    public float y;


    private void Start()
    {
        enemy_rig = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {

        if (canSeePlayer(AgroRange))
        {
            IsAgro = true;
        }
        else
        {
            if (IsAgro)
            {
                issearching = true;
                if (!issearching)
                {
                    issearching = true;
                    Invoke("stop_chase", 1);
                    patrol_mode.GetComponent<Enemy_patrol>().enabled = true;
                }
            }
        }
        if (IsAgro)
        {
            patrol_mode.GetComponent<Enemy_patrol>().enabled = false;
            chase_player();
        }
    }

    bool canSeePlayer(float distance)
    {
        bool val = false;
        var castDist = distance;

        if(facing_enemy)
        {
            castDist = -distance;
        }

        Vector2 endpos = castPoint.position + Vector3.right * castDist * transform.localScale.x;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endpos, 1 << LayerMask.NameToLayer("Action"));

        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                val = true;

            }
            else
            {
                val = false;
            }
            
        }

        if (val)
        {
            Debug.DrawLine(castPoint.position, hit.point, Color.green);
        }
        else
        {
            Debug.DrawLine(castPoint.position, endpos, Color.red);
        }
        return val;
    }

    public void chase_player()
    {
        if(transform.position.x < player.position.x)
        {
            //el enego esta de lado Izq, se movera a la Der
            enemy_rig.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(x, y);
            castPoint.localScale = new Vector2(1, 1);
            facing_enemy = false;
        }
        else if (transform.position.x > player.position.x)
        {
            //el enego esta de lado Der, se movera a la Izq
            enemy_rig.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-x, y);
            castPoint.localScale = new Vector2(-1, 1);
            facing_enemy = true;
        }
        
    }
    public void stop_chase()
    {
        IsAgro = false;
        issearching = true;
        enemy_rig.velocity = new Vector2(0, 0);
    }
}
