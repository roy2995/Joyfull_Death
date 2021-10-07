using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject FoodModel;
    public float _tiempoDeVida = 0f;
    public bool _termino = true;
    public string[] comidas;

    public bool hasPlate = false;
    public float fEatingTime = 10;
    private void Update()
    {
        if (_tiempoDeVida > 0f)
        {

            _tiempoDeVida -= Time.deltaTime;
            if (_tiempoDeVida <= 0)
            {
                Debug.Log("El cliente a finalizado su comida");
                _tiempoDeVida = 0f;
                _termino = true;
                hasPlate = false;
                Debug.Log("El cliente ha finalizado su comida y el plato ha sido retirado de la mesa");
                Destroy(this.gameObject);
            }
        }
    }

    public void GivePlate()
    {
        if (!hasPlate)
        {
            hasPlate = true;

            Instantiate(FoodModel, transform.position, transform.rotation);
            _tiempoDeVida = fEatingTime;
            Debug.Log("El cliente ha recibido su comida y demorara" + fEatingTime + " segundos");
        }

    }


    private void OnTriggerStay(Collider food)
    {
        Debug.Log("player a entrado al area");

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (food.gameObject.CompareTag("Player"))
            {
                GivePlate();

                if (_termino == false)
                {
                    Debug.Log("Se ha entregado la comida");
                }
            }
           
        }
    }

    /*IEnumerator timeStart()
    {
        _tiempoDeVida -= _tiempoDeVida / Time.deltaTime;
    }*/


}
