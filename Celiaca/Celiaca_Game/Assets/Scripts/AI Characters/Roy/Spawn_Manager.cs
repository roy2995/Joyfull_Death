using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [Header("spawners references")]
    [SerializeField] private GameObject[] spawners;
    [SerializeField] private GameObject[] clients;
    private bool[] sillas;

    [Header("settings")]
    public static int client_count;
    private bool activate = false;
    private int shair_num;
    private int client_num;
    public float pawn_dealy;


    private void Awake()
    {
        sillas = new bool[spawners.Length];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            activate = true;
            spawn_client();
        }
    }

    private void spawn_client()
    {
        if (activate)
        {
            StartCoroutine(NPCspawn());
        }
        else
        {
            return;
        }
    }

    IEnumerator NPCspawn()
    {
        shair_num = Random.Range(0, spawners.Length);
        client_num = Random.Range(0, clients.Length);
        if (!sillas[shair_num])
        {
            spawners[shair_num] = Instantiate(clients[client_num], spawners[shair_num].transform.position, Quaternion.identity);
            sillas[shair_num] = true;
        }
        Debug.Log(shair_num);
        yield return new WaitForSeconds(pawn_dealy);
        activate = false;
    }
}
