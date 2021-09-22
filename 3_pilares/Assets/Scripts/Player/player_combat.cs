using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_combat : MonoBehaviour
{
    [Header("Attack Settings")]
    public Animator animator;
    public Transform attack_point;
    public int attack_damge = 5;
    public float attack_rate = 2f;
    public AudioClip soundattack;
    public AudioSource audio;
    [Range(0, 10f)] public float attack_range = 0.5f;
    public LayerMask enemylayer;
    float next_attack_time = 0f;


    private void Update()
    {
        if(Time.time >= next_attack_time)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && Unlook_habilities.sword_attack == true)
            {
                attack();
                next_attack_time = Time.time + 1f / attack_rate;
            }
        }
    }

    void attack()
    {
        audio.clip = soundattack;
        audio.Play();
        animator.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attack_point.position,attack_range,enemylayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy);
            enemy.GetComponent<Enemy_Controller_2d>().TakeDamage_Enemy(attack_damge);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attack_point == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attack_point.position, attack_range);
    }
}
