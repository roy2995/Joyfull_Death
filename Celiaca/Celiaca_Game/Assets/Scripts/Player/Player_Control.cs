using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Control : MonoBehaviour
{
    [Header("Player Inputs")]
    [SerializeField] private PlayerInput inputs;
    private Vector3 inputvector;

    private void OnMove(InputValue value)
    {
        Vector2 inputMove = value.Get<Vector2>();
        inputvector = new Vector3(inputMove.x, 0, inputMove.y);
    }

}
