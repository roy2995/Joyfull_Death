using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    [Header("Move Settings")]
    public Character_Control2D controller;
    public float runSpeed = 40f;
    float horizontalMove = 0;
    bool jump = false;

    [Header("Dash Settings")]
    [Range(0, 300)] public float DashDistance;
    bool isdashing;
    float DoubleTapTime;
    KeyCode lastKeyCode;
    Rigidbody2D player_rig;
    public CapsuleCollider2D player_collider;
    public AudioSource dash_sound;
    public AudioClip dash_effect;

    [Header("Animator Settings")]
    public Animator player_animator;

    [Header("Healt")]
    private int healt = 1;
    public int current_healt;

    private void Start()
    {
        current_healt = healt;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player_rig = GetComponent<Rigidbody2D>();
        player_collider = GetComponent<CapsuleCollider2D>();
    }


    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        player_animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        if (jump == false && Unlook_habilities.dash == true)
            Dash();
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            player_animator.SetBool("Jumping", true);
        }

    }

    public void OnLanding()
    {
        player_animator.SetBool("Jumping", false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

    }

    private void Dash()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (DoubleTapTime > Time.time && lastKeyCode == KeyCode.A)
            {
                //dash active
                Debug.Log("enta en A");
                player_animator.SetTrigger("Dashing");
                player_collider.enabled = false;
                dash_sound.clip = dash_effect;
                dash_sound.Play();
                StartCoroutine(dash(-1f));
            }
            else
            {
                DoubleTapTime = Time.time + .5f;
            }
            lastKeyCode = KeyCode.A;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (DoubleTapTime > Time.time && lastKeyCode == KeyCode.D)
            {
                Debug.Log("enta en D");
                //dash active
                player_animator.SetTrigger("Dashing");
                player_collider.enabled = false;
                dash_sound.clip = dash_effect;
                dash_sound.Play();
                StartCoroutine(dash(1f));
            }
            else
            {
                DoubleTapTime = Time.time + .5f;
            }
            lastKeyCode = KeyCode.D;
        }
    }

    IEnumerator dash(float direction)
    {
        isdashing = true;
        player_rig.velocity = new Vector2(player_rig.velocity.x * direction, 0);
        player_rig.AddForce(new Vector2(DashDistance * direction,0),ForceMode2D.Impulse);
        yield return new WaitForSeconds(.1f);
        player_collider.enabled = true;
        //dash_sound.Pause();
    }

    public void TakeDamage_Player(int damge)
    {
        current_healt -= damge;
        Debug.Log(current_healt);
        Enemy_Controller_2d.attack_player = false;
        if (current_healt == 0)
        {

            die();
        }
    }

    private void die()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "plat")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {  
        transform.parent = null;
    }
}
