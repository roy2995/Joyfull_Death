using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;
    public bool isflipped = true;

    public void lookatplayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && isflipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isflipped = false;
        }
        else if(transform.position.x < player.position.x && !isflipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isflipped = true;
        }
    }
}
