using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hailities_check : MonoBehaviour
{
    public string habilidad;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(habilidad == "sword")
            {
                Unlook_habilities.sword_attack = true;
            }
        }

        else if (collision.gameObject.tag == "Player")
        {
            if (habilidad == "Dash")
            {
                Unlook_habilities.dash = true;
            }
        }

    }
}
