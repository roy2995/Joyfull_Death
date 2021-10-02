using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChairTrigger : MonoBehaviour
{
    public RequestManager _escribirPedido;

    public string[] platillos;

    public GameObject _Paper;
    public Text _texto;

    Queue<string> _pedido;

    string activeSentence;
    public float SentenceSpeed;

    AudioSource _AudioS;
    public AudioClip speakSound;

    public bool _takeOrder;

    //Se toma el objeto a quien haremos la notificacion cuando se siente, en
    // este caso es un Image.
    public GameObject PopUpNoty;

    void Start()
    {
        //Se mantiene apagado hasta que se siente
        PopUpNoty.SetActive(false);

        _pedido = new Queue<string>();
        _AudioS = GetComponent<AudioSource>();
    }

    void StartWriting()
    {
        _pedido.Clear();

        foreach(string pedidos in _escribirPedido.ListadePlatillos)
        {
            _pedido.Enqueue(pedidos);
        }

        DisplayNextSentence();
    }

    void DisplayNextSentence()
    {
        if(_pedido.Count <= 0)
        {
            _texto.text = activeSentence;
            return;
        }

        activeSentence = _pedido.Dequeue();
        _texto.text = activeSentence;

        StopAllCoroutines();
        StartCoroutine(TyperSentences(activeSentence));
    }

    void FixedUpdate()
    {
        if (_takeOrder)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Se inicio a tomar la orden");
                DisplayNextSentence();
            }
        }
    }



    // Si detecta al player entrar a la silla, comenzara la corrutina de Pop up.
    private void OnTriggerEnter(Collider npc)
    {
        if(npc.tag == "Client")
        {
            Debug.Log("Is Sitting on the chair");
            StartCoroutine("PopupTimerDelay");

            if (npc.CompareTag("Player"))
            {
                _takeOrder = true;
                _Paper.SetActive(true);
                Debug.Log("El player esta tomando la orden del cliente");
                StartWriting();
            }
        }
    }

    IEnumerator TyperSentences(string sentence)
    {
        _texto.text = "";

        foreach(char letra in sentence.ToCharArray())
        {
            _texto.text += letra;
            _AudioS.PlayOneShot(speakSound);
            yield return new WaitForSeconds(SentenceSpeed);
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
