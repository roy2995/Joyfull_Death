using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [Header("Cams references")]
    public Camera Cam_Game;
    public Camera Cam_Request;

    private void Awake()
    {
        Cam_Game = GetComponent<Camera>();
        Cam_Request = GetComponent<Camera>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player_Movement.invert = 1;
            Cam_Game.depth = 1;
            Cam_Request.depth = 2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player_Movement.invert = -1;
            Cam_Request.depth = 1;
            Cam_Game.depth = 2;
        }

    }
}
