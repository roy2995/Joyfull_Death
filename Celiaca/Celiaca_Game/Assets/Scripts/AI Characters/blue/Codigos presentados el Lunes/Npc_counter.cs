using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Npc_counter : MonoBehaviour
{
    [Header("Count Settings")]
    public int _npcInGame;
    private int count;
    public bool _spawnInGame;

    //[Header("Component Settings")]
    //public GameObject _lostCondition;

    void Start()
    {
        count = 0;
        _npcInGame = GameObject.FindGameObjectsWithTag("Client").Length;
        npcIntheArea();
        //_lostCondition.SetActive(false);
    }

    /*private void OnTriggerEnter(Collider npc_client)
    {
        if(npc_client.gameObject.tag == "Client")
        {
            count += 1;
        }
        else //En caso de que el npc se vaya
        {
            count -= 1;
        }    
    }*/

    public void npcIntheArea()
    {
        if (_spawnInGame)
        {
            _npcInGame = count;
        }
    }
}
