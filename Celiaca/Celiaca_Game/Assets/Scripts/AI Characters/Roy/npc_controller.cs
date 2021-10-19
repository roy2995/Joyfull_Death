using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npc_controller : MonoBehaviour
{
    [Header("time to client")]
    public GameObject canvas;
    public float duration;
    public int num_shair;//esto es paracuando deje el aciento lo cambia a falso
    public Image img_states;
    public static bool attended = false;
    public float timer;
    private bool destoy;

    [SerializeField] Color current;
    [SerializeField] Color start;
    [SerializeField] Color end;

    [Header("Order Manager")]
    public float setenece_speed;
    public string Client; //se supone que agarra el nombre de la persona, en este caso el Cliente.
    [TextArea(3, 10)]
    public string[] order_list;

    Queue<string> orders;
    public Text text;
    string sentence;
    public GameObject note;

    AudioSource write_sound;
    AudioClip speak_sound;

    private void Start()
    {
        orders = new Queue<string>();
        write_sound = GetComponent<AudioSource>();
    }
    private void Update()
    {
        waitingService();
        WaitingToEat();
    }

    //funcion de pedidos
    public void StartWriting()
    {
        orders.Clear();
        foreach(string pedidos in order_list)
        {
            orders.Enqueue(pedidos);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(orders.Count <= 0)
        {
            text.text = sentence;
            return;
        }
        sentence = orders.Dequeue();
        text.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeOrder(sentence));
    }

    IEnumerator TypeOrder(string sentences)
    {
        note.SetActive(true);
        text.text = " ";
        foreach(char letra in sentences.ToCharArray())
        {
            text.text += letra;
            write_sound.PlayOneShot(speak_sound);
            yield return new WaitForSeconds(setenece_speed);
        }
    }


    //funcion de inicio de espera
    public void waitingService()
    {
        if(timer <= duration && !attended)
        {
            timer += Time.deltaTime;
            current = Color.Lerp(start, end, timer / duration);
            img_states.color = current;
        }
        if(timer >= duration && !attended)
        {
            if (Spawn_Manager.sillas[num_shair] == true)
            {
                Debug.Log("si detecta en que silla esta sentado");
                Spawn_Manager.sillas[num_shair] = false;
            }
            Destroy(this.gameObject);
        }
    }

    public void WaitingToEat()
    {
        if (attended)
        {
            Debug.Log("regista si lo atnedio");
            canvas.SetActive(false);
            if (timer <= duration && attended)
            {
                timer += Time.deltaTime;
            }

            if(timer >= duration)
            {
                //puntaje
                destoy = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ensalada"))
        {
            Debug.Log("detecta la comida");
            attended = true;
        }

        if (other.CompareTag("Hamburgesa"))
        {
            Debug.Log("detecta la comida");
            attended = true;
        }

        if (other.CompareTag("macarrones"))
        {
            Debug.Log("detecta la comida");
            attended = true;
        }
        if (other.CompareTag("Pizza"))
        {
            Debug.Log("detecta la comida");
            attended = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ensalada"))
        {
            if (destoy)
            {
                Destroy(other);
            }
        }

        if (other.CompareTag("Hamburgesa"))
        {
            if (destoy)
            {
                Destroy(other);
            }
        }

        if (other.CompareTag("macarrones"))
        {
            if (destoy)
            {
                Destroy(other);
            }
        }
        if (other.CompareTag("Pizza"))
        {
            if (destoy)
            {
                Destroy(other);
            }
        }
    }
}
