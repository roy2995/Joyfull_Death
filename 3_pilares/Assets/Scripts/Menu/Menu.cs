using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    [Header("game object buttons")]
    public bool gamemenu = false;
    public GameObject pause;
    public GameObject options;
    public GameObject firstButton;
    public GameObject optiosnFirstbutton;
    public GameObject optiosnClosetbutton;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gamemenu)
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if (!pause.activeInHierarchy)
        {
            pause.SetActive(true);
            Time.timeScale = 0;
            EventSystem.current.SetSelectedGameObject(null);

            EventSystem.current.SetSelectedGameObject(firstButton);
        }
        else
        {
            pause.SetActive(false);
            Time.timeScale = 1;
            options.SetActive(false);
        }
    }

    public void OpenOption()
    {
        options.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(optiosnFirstbutton);
    }

    public void CloseOption()
    {
        options.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(firstButton);
    }
}
