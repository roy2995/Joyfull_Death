using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_generate : MonoBehaviour
{
    [Header("Head Spawn Settings")]
    public Spawn_Points_sets head;
    public string spawn_num;

    [Header("Client Array")]
    public GameObject[] clients;
    private GameObject cliente;

    private void Start()
    {
        head = GetComponent<Spawn_Points_sets>();
    }

    private void Update()
    {
        if (spawn_num == "spawn_1" && Spawn_Points_sets.open_spawn_1 == true)
        {
            Spawn_go();
            Spawn_Points_sets.open_spawn_1 = false;
        }
        else if (spawn_num == "spawn_2" && Spawn_Points_sets.open_spawn_2 == true)
        {
            Spawn_go();
            Spawn_Points_sets.open_spawn_2 = false;
        }
    }

    public void Spawn_go()
    {
        //es casi lo mismo que tienes solo que esta mas resumido ya que no se requiere de mucho peoceso
        cliente = clients[Random.Range(0, clients.Length)];

        cliente = Instantiate(cliente) as GameObject;
    }

}
