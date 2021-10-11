using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManagerScript : MonoBehaviour
{
    [SerializeField]
    public GameObject playerRef;
    public GameObject[] foods;
    public bool _playerIsClose = false;


    void Start()
    {
        foods = GameObject.FindGameObjectsWithTag("Food");
        foreach (GameObject _foodRef in foods)
        {
            _foodRef.SetActive(false);
        }
    }

    void OnTriggerStay(Collider ActivePlate)
    {
        if (ActivePlate.gameObject.CompareTag("Player"))
        {
            _playerIsClose = true;
            foreach (GameObject _foodRef in foods)
            {
                _foodRef.SetActive(true);
                Debug.Log("Player has enter the table");
            }
        }
    }

    /*private void OnTriggerExit(Collider DeactivatePlate)
    {
        if (DeactivatePlate.gameObject.CompareTag("Player"))
        {
            _playerIsClose = false;
            foreach (GameObject _foodRef in foods)
            {
                _foodRef.SetActive(false);
                Debug.Log("Player has left the table");
            }
        }
    }*/
}
