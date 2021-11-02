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
}
