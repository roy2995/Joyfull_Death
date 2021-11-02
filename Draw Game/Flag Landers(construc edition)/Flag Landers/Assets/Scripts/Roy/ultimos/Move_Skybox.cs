using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Skybox : MonoBehaviour
{
    public float velocity_rotation;

    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * velocity_rotation);
    }
}
