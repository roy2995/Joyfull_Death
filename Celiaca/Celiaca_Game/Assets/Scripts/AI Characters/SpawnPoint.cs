using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Se usa dos arrays para hacer el spawner uno quien toma el prefab y el npc[] es quien transforma
    // esta instancia a un nuevo GameObject ya que si pongo el array solo crea un tipo de problema donde no me permite
    // usar un array dentro del Instantiate.

    public GameObject[] npcPrefab;
    public GameObject[] npc;
    public float _Timer;

    void Start()
    {
        StartCoroutine(_npcSpawner());
    }

    IEnumerator _npcSpawner()
    {
        // Mencionado anteriormente
        // se define que npc es quien tomara los valores de npcPrefab dependiendo de cuantos sean.
        npc = new GameObject[npcPrefab.Length];

        // Se traduce la cantidad del array y se le establece al nuevo array npc.
        for (int i = 0; i < npcPrefab.Length; i++)
        {
            // Se establece que el nuevo array instanciara a los objetos como gameObjects.
            npc[i] = Instantiate(npcPrefab[i]) as GameObject;
        }
        yield return new WaitForSeconds(5f);
    }
}
