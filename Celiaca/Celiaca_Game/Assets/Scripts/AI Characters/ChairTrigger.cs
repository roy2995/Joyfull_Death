using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairTrigger : MonoBehaviour
{

    public GameObject PopUpNoty;

    void Start()
    {
        PopUpNoty.SetActive(false);
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider npc)
    {
        if(npc.tag == "AIbot")
        {
            Debug.Log("Is Sitting on the chair");
            StartCoroutine("PopupTimerDelay");
        }
    }

    IEnumerator PopupTimerDelay()
    {
        PopUpNoty.SetActive(false);

        yield return new WaitForSeconds(10f);
        PopUpNoty.SetActive(true);
    }
}
