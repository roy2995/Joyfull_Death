using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npc_controller : MonoBehaviour
{
    [Header("time to client")]
    public float duration;
    public int num_shair;//esto es paracuando deje el aciento lo cambia a falso
    public Image img_states;
    public static bool attended;
    public float timer;
    [SerializeField] Color current;
    [SerializeField] Color start;
    [SerializeField] Color end;

    [Header("Order Manager")]
    public int setenece_speed;
    public string list;
    [TextArea(3, 10)]
    public string[] order_list;
    Queue<string> orders;
    public Text text;
    string sentence;
    public GameObject note;
    AudioSource write_sound;
    AudioClip speak_sound;

    private void Update()
    {
        waitingService();
    }

    //funcion de pedidos
    public void StartWriting()
    {
        orders.Clear();
        foreach(string pedidos in order_list)
        {
            orders.Enqueue(pedidos);
        }
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

    IEnumerator TypeOrder(string sentence)
    {
        note.SetActive(true);
        text.text = " ";
        foreach(char letra in sentence.ToCharArray())
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
            timer = 0f;
            duration += 10;
            if (timer <= duration && attended)
            {
                timer += Time.deltaTime;
                current = Color.Lerp(start, end, timer / duration);
                img_states.color = current;
            }
        }
    }
}
