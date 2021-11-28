using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plate_active : MonoBehaviour
{
    [Header("Plate Settings")]
    public Animator animator;
    public static bool active_door = false;









    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box") || collision.CompareTag("Player"))
        {
            animator.SetBool("Active", true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Box") || collision.CompareTag("Player"))
        {
            animator.SetBool("Active", true);
            active_door = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("Active", false);
    }
}
