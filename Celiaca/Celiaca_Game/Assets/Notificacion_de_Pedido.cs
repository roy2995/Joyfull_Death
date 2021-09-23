using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notificacion_de_Pedido : MonoBehaviour
{
    public GameObject FloatingText;

    private void Start()
    {
        FloatingText.SetActive(false);
    }
    private void OnTriggerEnter(Collider client)
    {
        if (client.tag == "Silla")
        {
            StartCoroutine("PopUpHelp");
            Debug.Log("Esta sentado");
        }
    }

    IEnumerator PopUpHelp()
    {
        FloatingText.SetActive(false);
        yield return new WaitForSeconds(10f);

        FloatingText.SetActive(true);
    }
}
