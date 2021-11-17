using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptions : MonoBehaviour
{

    public GameObject Options_Panel;
    public GameObject Options_TurnOn;
    public GameObject Options_TurnOff;

    void Start()
    {
        Options_Panel.SetActive(false);
    }

    void Update()
    {
        
    }

    public void OptionsOn()
    {
        Options_Panel.SetActive(true);
    }

    public void OptionsOff()
    {
        Options_Panel.SetActive(false);
    }
}
