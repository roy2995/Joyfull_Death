using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//El proposito de este codigo es para instanciar un o multiples objetos dentro del mapa en start con una posicion en
// x y en z.
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
        while (_NpcCounter < 2)
        {
            xPos = Random.Range(-20, 50);
            zPos = Random.Range(20, -50);

            Instantiate(_npcClient, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(.1f);
            _NpcCounter += 1;
        }
    }
}
