using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBrush : MonoBehaviour
{
    public GameObject brush1;
    public GameObject brush2;
    public GameObject brush3;

    public bool _activeBrush1;
    public bool _activeBrush2;
    public bool _activeBrush3;

    void Start()
    {
        brush1.SetActive(true);
        brush2.SetActive(false);
        brush3.SetActive(false);

        _activeBrush1 = true;
        _activeBrush2 = false;
        _activeBrush3 = false;
    }

    void Update()
    {
        if ((_activeBrush1 == false || _activeBrush2 == false) && (Input.GetKey(KeyCode.Alpha1)))
        {
            brush1.SetActive(true); 
            brush2.SetActive(false); 
            brush3.SetActive(false);

            _activeBrush1 = true;
            _activeBrush2 = false;
            _activeBrush3 = false;

            Debug.Log("se ha cambiado de a: " + brush1);

        }

        if ((_activeBrush3 == false || _activeBrush2 == false) && (Input.GetKey(KeyCode.Alpha2)))
        {
            brush1.SetActive(false);
            brush2.SetActive(true);
            brush3.SetActive(false);

            _activeBrush1 = false;
            _activeBrush2 = true;
            _activeBrush3 = false;

            Debug.Log("se ha cambiado de a: " + brush2);
        }

        if ((_activeBrush1 == false || _activeBrush3 == false) && (Input.GetKey(KeyCode.Alpha3)))
        {
            brush1.SetActive(false);
            brush2.SetActive(false);
            brush3.SetActive(true);

            _activeBrush1 = false;
            _activeBrush2 = false;
            _activeBrush3 = true;

            Debug.Log("se ha cambiado de a: " + brush3);

        }
    }
}
