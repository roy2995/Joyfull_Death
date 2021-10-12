using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taketheorder : MonoBehaviour
{

    public bool isPickable = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInParent<PickUp>().ObjectToPickup = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInParent<PickUp>().ObjectToPickup = null;
        }
    }
}
