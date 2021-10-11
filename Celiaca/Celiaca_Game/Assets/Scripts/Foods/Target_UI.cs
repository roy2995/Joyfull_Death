using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_UI : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FoodSpawner.open = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FoodSpawner.open = false;
        }
    }
}
