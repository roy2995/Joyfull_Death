using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambiodeecena : MonoBehaviour
{
    public string nombreecena;
    public void startbtn()
    {
        SceneManager.LoadScene(nombreecena);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(nombreecena);
    }
}
