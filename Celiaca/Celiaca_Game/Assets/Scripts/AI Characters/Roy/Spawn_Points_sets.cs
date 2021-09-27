using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Points_sets : MonoBehaviour
{
    [Header("Spawns sets")]//esto lo que hara es facilitarnos el control de los spawners ya que podemos llamarlos de manera simultanea sin problemas
    public GameObject spawn_1;
    public GameObject spawn_2;

    [Header("Settings")] // con esto tendremos un contro de los clientes que estan dentro del restaurante
    public static int client_count;
    public int freeShairs;
    private int rand_spawn;
    public static bool open_spawn_1;
    public static bool open_spawn_2;

    private void Start()
    {
        spawn_1 = GetComponent<GameObject>();
        spawn_2 = GetComponent<GameObject>();
    }

    private void Update()
    {
        if(client_count < freeShairs)
        {
            spawnselect();
        }
    }



    public void spawnselect()
    {
        rand_spawn = Random.Range(0, 1);
        if (rand_spawn == 0)
        {
            
        }
        else if(rand_spawn == 1)
        {

        }
    }

}



