using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject FoodModel;
    public float _tiempoDeVida;
    public bool _termino = false;
    public string[] comidas;

    private void Start()
    {
        FoodModel.SetActive(false);
    }

    public void GivePlate()
    {
        if (_termino)
        {
            if (_tiempoDeVida > 2f)
            {
                _tiempoDeVida -= Time.deltaTime;
                Debug.Log("El cliente ha recibido su comida y demorara 10 segundos");
            }
            else
            {
                Debug.Log("El cliente a finalizado su comida");
                _tiempoDeVida = 0;
                _termino = true;
                FoodModel.SetActive(false);
            }
        }
    }

    private void OnTriggerStay(Collider food)
    {
        if (food.gameObject.CompareTag ("Player"))
        {
            if (_termino == false)
            {
                GivePlate();
                
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        FoodModel.SetActive(true);
                        Instantiate(FoodModel, transform.position, transform.rotation);
                        Debug.Log("Se ha entregado la comida");


                    }

                if (_termino == true)
                {
                    Debug.Log("El plato ha sido retirado de la mesa");
                }
            }
            
            
        }
    }


}
