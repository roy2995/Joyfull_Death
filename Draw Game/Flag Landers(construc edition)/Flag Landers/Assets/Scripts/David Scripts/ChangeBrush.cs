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

    private void Start()
    {
        brush1.SetActive(true);
        brush2.SetActive(false);
        brush3.SetActive(false);
    }

    private void Update()
    {
        if ((brush1 == false || brush2 == false) && (Input.GetKey(KeyCode.Alpha1)))
        {
            brush1.SetActive(true); 
            brush2.SetActive(false); 
            brush3.SetActive(false);

            _activeBrush1 = true;
            _activeBrush2 = false;
            _activeBrush3 = false;

        }

        if ((brush3 == false || brush2 == false) && (Input.GetKey(KeyCode.Alpha2)))
        {
            brush1.SetActive(false);
            brush2.SetActive(true);
            brush3.SetActive(false);

            _activeBrush1 = false;
            _activeBrush2 = true;
            _activeBrush3 = false;

        }

        if ((brush1 == false || brush3 == false) && (Input.GetKey(KeyCode.Alpha3)))
        {
            brush1.SetActive(false);
            brush2.SetActive(false);
            brush3.SetActive(true);

            _activeBrush1 = false;
            _activeBrush2 = false;
            _activeBrush3 = true;

        }
    }
}
