using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class siguientelvl : MonoBehaviour
{
    public void next(string sceneToLoade)
    {
        SceneManager.LoadScene(sceneToLoade);
    }

    public void QuitScene()
    {
        Application.Quit();
        Debug.Log("Player has quit");
    }

    public void resetCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
