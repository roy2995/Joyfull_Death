using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move_2 : MonoBehaviour
{
    [Header("Active Controller")]
    public bool player_2 = false;
    [Header("Move Settings")]
    public Character_Control2D controller;
    public float runSpeed = 40;
    float horizontalMove = 0;
    bool jump = false;

    [Header("Animation")]
    [SerializeField] private Animator player_animator;

    private void Update()
    {
        if (player_2)
        {
            Move();
        }
    }

    private void FixedUpdate()
    {
        if (player_2)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
    }

    public void OnLanding()
    {
        player_animator.SetBool("Jumping", false);
    }

    public void Move()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        player_animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            player_animator.SetBool("Jumping", true);
        }
    }
}
