using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hailities_check : MonoBehaviour
{
    public string habilidad;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Player")
        {
            if(habilidad == "sword")
            {
                Unlook_habilities.sword_attack = true;
            }
        }

       if (collision.gameObject.tag == "Player")
        {
            if (habilidad == "Dash")
            {
                Debug.Log(Unlook_habilities.dash);
                Unlook_habilities.dash = true;
            }
        }

    }
}
