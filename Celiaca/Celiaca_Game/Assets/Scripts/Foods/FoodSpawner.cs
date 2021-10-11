using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FoodSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject request_UI;
    public GameObject op_UI;
    public GameObject[] Spawn_points;
    public GameObject[] Food;
    public static bool[] bar_ocuped;
    [Header("Request Food Settings")]
    public static bool open = false;
    public GameObject Notification;

    private void Start()
    {
        bar_ocuped = new bool[Spawn_points.Length];
        request_UI.SetActive(false);
        op_UI.SetActive(false);
    }

    private void Update()
    {
        // para que el UI se habra
        if (open)
        {
            CManager.C_active = true;
            request_UI.SetActive(true);
        }
        if (!open)
        {
            request_UI.SetActive(false);
        }
    }

    // para que abra el ui
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            open = true;
        }
    }

    public void MiniPizza()
    {
        if(bar_ocuped[0] == false)
        {
            Instantiate(Food[0], Spawn_points[0].transform.position, Quaternion.identity);
            bar_ocuped[0] = true;

        }

        if(bar_ocuped[0]== true)
        {
            Notification.SetActive(true);
        }
        
    }

    public void ensalada()
    {
        if (bar_ocuped[1] == false)
        {
            Instantiate(Food[1], Spawn_points[1].transform.position, Quaternion.identity);
            bar_ocuped[1] = true;
        }
        
    }

    public void macarrones()
    {
        Instantiate(Food[2], Spawn_points[2].transform.position, Quaternion.identity);
    }

    public void hambuergesa()
    {
        Instantiate(Food[3], Spawn_points[3].transform.position, Quaternion.identity);
    }
}
