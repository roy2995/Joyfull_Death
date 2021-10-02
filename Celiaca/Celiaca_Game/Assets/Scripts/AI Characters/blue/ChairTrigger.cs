using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairTrigger : MonoBehaviour
{

    //Se toma el objeto a quien haremos la notificacion cuando se siente, en
    // este caso es un RawImage.
    public GameObject PopUpNoty;

    void Start()
    {
        //Se mantiene apagado hasta que se siente
        PopUpNoty.SetActive(false);
    }

    // Si detecta al player entrar a la silla, comenzara la corrutina de Pop up.
    private void OnTriggerEnter(Collider npc)
    {
        if(npc.tag == "Client")
        {
            Debug.Log("Is Sitting on the chair");
            StartCoroutine("PopupTimerDelay");
        }
    }

    // Aqui se espera por 10 segundo para que la imagen se active.
    IEnumerator PopupTimerDelay()
    {
        PopUpNoty.SetActive(false);

        yield return new WaitForSeconds(2f);
        PopUpNoty.SetActive(true);
    }
}
