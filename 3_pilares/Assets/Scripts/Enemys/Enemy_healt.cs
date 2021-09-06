using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_healt : MonoBehaviour
{
    public int healt = 1;
    int currentHealt;

    private void Start()
    {
        currentHealt = healt;
    }

    public void TakeDamage(int damage)
    {
        currentHealt -= damage;
        Debug.Log("funciona");

        if (currentHealt <= 0)
        {
            die();
        }
    }

    void die()
    {
        Destroy(this.gameObject);
    }
}
