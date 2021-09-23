using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    [Header("Player Movement")]
    public CharacterController controller;
    public float Speed = 100f;

    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if(direction.magnitude >= 0.01f)
        {
            controller.Move(direction * Speed * Time.deltaTime);
        }
    }
}
