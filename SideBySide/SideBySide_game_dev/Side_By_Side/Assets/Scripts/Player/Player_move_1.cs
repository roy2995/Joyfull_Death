using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move_1 : MonoBehaviour
{
    [Header("Active Controller")]
    public bool player_1 = false;
    [Header("Move Settings")]
    public Character_Control2D controller;
    public float runSpeed = 40;
    float horizontalMove = 0;
    bool jump = false;

    [Header("Animation")]
    [SerializeField] private Animator player_animator;

    [Header("Push & Pull Settings")]
    public float Distance;
    RaycastHit2D hit;
    public GameObject ray_pull;


    private void Update()
    {
        if (player_1)
        {
            Move();
            raycasts_pull();
        }
    }

    private void FixedUpdate()
    {
        if (player_1)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;

        }
    }

    public void OnLanding()
    {
        player_animator.SetBool("Jumping", false);
    }

    public void raycasts_pull()
    {
        hit = Physics2D.Raycast(ray_pull.transform.position, Vector2.right, Distance);
        Debug.DrawRay(ray_pull.transform.position, Vector2.right * Distance, Color.green);
        if (hit.collider.tag == "Box")
        {
            player_animator.SetBool("Push", true);
        }
        else
        {
            player_animator.SetBool("Push", false);
        }
    }

    public void Move()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        player_animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (horizontalMove <= -0.01f)
            Distance = -0.5f;
        else if(horizontalMove >= 0f)
            Distance = 0.5f;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            player_animator.SetBool("Jumping", true);
        }
    }
}
