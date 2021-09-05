using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue_Manager : MonoBehaviour
{
    public MentorDialogue dialogue;

    Queue<string> sentences;

    public GameObject dialoguePanel;
    public TextMeshProUGUI displayText;

    string activeSentence;
    public float SentenceSpeed;

    AudioSource myAudio;
    public AudioClip speakSound;

    public bool CanSpeak = false;

    void Start()
    {
        sentences = new Queue<string>();
        myAudio = GetComponent<AudioSource>();
    }

    void StartDialogue()
    {
        sentences.Clear();

        foreach(string sentence in dialogue.sentenceList)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    void DisplayNextSentence()
    {
        if(sentences.Count <= 0){
            displayText.text = activeSentence;
            return;
        }

        activeSentence = sentences.Dequeue();
        displayText.text = activeSentence;

        StopAllCoroutines();
        StartCoroutine(TyperSentences(activeSentence));
    }

    IEnumerator TyperSentences(string sentence)
    {
        displayText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            displayText.text += letter;
            myAudio.PlayOneShot(speakSound);
            yield return new WaitForSeconds(SentenceSpeed);
        }
    }

    void Update()
    {
        if (CanSpeak)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Se toco E");
                DisplayNextSentence();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            CanSpeak = true;
            dialoguePanel.SetActive(true);
            Debug.Log("Entro Trigger");
            StartDialogue();
        }
    }

    void OnTriggerExit2D(Collider2D Fuchi)
    {
        if (Fuchi.CompareTag("Player"))
        {
            CanSpeak = false;
            Debug.Log("Salio Trigger");
            dialoguePanel.SetActive(false);
        }
    }
}