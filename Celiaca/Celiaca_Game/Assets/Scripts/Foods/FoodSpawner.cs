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
    [Header("Request Food Settings")]
    private bool open = false;

    private void Start()
    {
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
    }

    // para que abra el ui
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            open = true;
        }
    }
}
