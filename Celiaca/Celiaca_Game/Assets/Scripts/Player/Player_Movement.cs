using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Player Movement")]
    public CharacterController controller;
    public float Speed = 100f;
    public float turnSmoothTime = .1f;
    private float turnsmoothvelocity;

    [Header("timer")]
    [SerializeField] private timer timer;
    public int time;

    private void Start()
    {
        timer.SetDuration(time).Begin();
    }
    private void Update()
    {
        Move_Player();
    }

    private void Move_Player()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(Vertical * -1, 0f, Horizontal).normalized;
        if (direction.magnitude >= .1f)
        {
            float tragetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, tragetAngle, ref turnsmoothvelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(direction * Speed * Time.deltaTime);
        }

    }
}
