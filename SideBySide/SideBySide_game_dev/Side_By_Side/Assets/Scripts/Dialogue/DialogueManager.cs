using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Dialogue dialogue;

    public Text nameText;
    public Text dialogueText;
    public GameObject dialoguePanel;
    private Queue<string> sentences;


    AudioSource myAudio;
    public AudioClip speakSound;

    public bool CanSpeak = false;

    void Start()
    {
        sentences = new Queue<string>();
        myAudio = GetComponent<AudioSource>();
    }

    public void StartDialogue()
    {
        //Debug.Log("starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentences();

    }
    public void DisplayNextSentences()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            myAudio.PlayOneShot(speakSound);
            yield return null;
        }
    }

    public void EndDialogue()
    {
        Debug.Log("End of conversation");
    }

    private void Update()
    {
        if (CanSpeak)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CanSpeak = true;
                dialoguePanel.SetActive(true);
                {
                    Debug.Log("Seguir al siguiente dialogo");
                    DisplayNextSentences();
                    
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D Entry)
    {
        if (Entry.CompareTag("Player"))
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
