using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_generate : MonoBehaviour
{
    [Header("Head Spawn Settings")]
    public Spawn_Points_sets head;

    [Header("Client Array")]
    public GameObject[] clients;
    private GameObject cliente;

    private void Start()
    {
        head = GetComponent<Spawn_Points_sets>();
    }

    private void Update()
    {
        if(Spawn_Points_sets.open_spawn_1 == true)
        {
            Spawn_1_go();
        }
    }

    public void Spawn_1_go()
    {
        //es casi lo mismo que tienes solo que esta mas resumido ya que no se requiere de mucho peoceso
        cliente = clients[Random.Range(0, clients.Length)];

        cliente = Instantiate(cliente) as GameObject;
    }

}
