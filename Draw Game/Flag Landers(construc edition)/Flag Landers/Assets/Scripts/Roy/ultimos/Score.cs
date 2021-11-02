using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [Header("Score Settings")]
    public int end_score;
    [SerializeField]
    public GameObject Score_system;
    public List<Collider> ballcount = new List<Collider>();
    public Text score;
    private bool time_of = false;
    private bool end = false;
    private float current_time = 10;

    private void Awake()
    {
        Score_system.SetActive(false);
    }

    private void Update()
    {
        if (time_of)
        {
            StartCoroutine(time_off());
        }

        if (end || ballcount.Count == 5)
        {
            StopCoroutine(time_off());
            current_time = 0f;
            Score_system.SetActive(true);
            end_score = ballcount.Count * 500;
            score.text = end_score.ToString();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("tagert_score"))
        {
            ballcount.Add(other);
            if (!time_of)
            {
                time_of = true;
            }
        }
    }

    IEnumerator time_off()
    {
        if(current_time > 0 && !end)
        {
            current_time -= Time.deltaTime;
            Debug.Log(current_time);
        }

        if (current_time <= 0 || end)
        {
            end = true;
            time_of = false;
        }

            yield return new WaitForSeconds(1f);
    }
}
