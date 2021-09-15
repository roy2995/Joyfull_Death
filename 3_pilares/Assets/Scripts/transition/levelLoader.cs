using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{
    [Header("Loader Scene")]
    public Animator transition;
    public float transitiontime = 1;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LoadNextLevel();
    }

    IEnumerator LoadLevel(int index)
    {
        Debug.Log("entra a la corrutina");
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(index);
    }
}
