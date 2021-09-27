using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    public GameObject[] npcPrefab;
    public GameObject[] npc;
    public float _Timer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_npcSpawner());
    }

    IEnumerator _npcSpawner()
    {

        npc = new GameObject[npcPrefab.Length];

        for (int i = 0; i < npcPrefab.Length; i++)
        {
            npc[i] = Instantiate(npcPrefab[i]) as GameObject;

            npc[1].SetActive(true);
            npc[2].SetActive(true);

        }
        yield return new WaitForSeconds(5f);
    }
}
