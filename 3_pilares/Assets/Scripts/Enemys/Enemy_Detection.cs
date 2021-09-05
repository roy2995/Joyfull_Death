using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Detection : MonoBehaviour
{
    [Header("Enemiy Detection")]
    public Component patrol_mode;
    public Transform player;
    public float AgroRange;
    public float moveSpeed;
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
        float distances = Vector2.Distance(transform.position, player.position);
       
        if (distances < AgroRange)
        {
            //chase player & stop patrol
            patrol_mode.GetComponent<Enemy_patrol>().enabled = false;
            chase_player();
            
        }
        else
        {
            //stop chase & continue patrol
            patrol_mode.GetComponent<Enemy_patrol>().enabled = true;
            stop_chase();
        }
    }

    public void chase_player()
    {
        if(transform.position.x < player.position.x)
        {
            //el enego esta de lado Izq, se movera a la Der
            enemy_rig.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(x, y);
            
        }
        else if (transform.position.x > player.position.x)
        {
            //el enego esta de lado Der, se movera a la Izq
            enemy_rig.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-x, y);
            
        }
        
    }
    public void stop_chase()
    {
        enemy_rig.velocity = new Vector2(0, 0);
    }
}
