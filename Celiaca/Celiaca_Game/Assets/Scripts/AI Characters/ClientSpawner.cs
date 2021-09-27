using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//El proposito de este codigo es para instanciar un o multiples objetos dentro del mapa en start con una posicion en
// x y en z.

// Basicamente spawneas la cantidad de Npc dentro de un rango y el codigo hara spawn de ellos en ubicaciones rand.
public class ClientSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject _npcClient;

    public int xPos;
    public int zPos;

    public int _NpcCounter;



    void Start()
    {
        StartCoroutine(_NpcDrop());
    }

    // Update is called once per frame

    IEnumerator _NpcDrop()
    {
        // se establece la cantidad de enemigos que quieres dentro.
        while (_NpcCounter < 2)
        {
            //das el rango de X y Z
            xPos = Random.Range(-20, 50);
            zPos = Random.Range(20, -50);

            // Instancias el objeto con su vector de xPos, y zPos. No necesitamos Y pero quizas me este equivocando.
            Instantiate(_npcClient, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(.1f);

            // Aqui solo va añadiendo Npc al mapa o mas bien envia las instancias al mapa.
            _NpcCounter += 1;
        }
    }
}
