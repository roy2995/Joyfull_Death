using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character_Control2D : MonoBehaviour
{
    [Header("Character Settings")]
    public float max_JumpForce = 400f;
    [Range(0, 1)] public float max_crouchSpeed = .36f;
    [Range(0, .3f)] public float max_MoveSmooth = .05f;
    public bool aircontrol = false;
    [SerializeField] private LayerMask groundtag;
    [SerializeField] private Transform goundcheck;
    [SerializeField] private Transform ceilingcheck;
    [SerializeField] private Collider2D crounchDiseableCollider;

    [Header("privates settings")]
    const float groundedRadius = .2f;
    private bool grounded;
    const float ceillingradius = .2f;
    private Rigidbody2D player_rig;
    private bool facingRight = true;
    private Vector3 velocity = Vector3.zero;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool wasCrouching = false;

    private void Awake()
    {
        player_rig = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = grounded;
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(goundcheck.position, groundedRadius, groundtag);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }

    public void Move(float move, bool crouch, bool jump)
    {
        if (!crouch)
        {
            if(Physics2D.OverlapCircle(ceilingcheck.position, ceillingradius, groundtag))
            {
                crouch = true;
            }
        }

        if(goundcheck || aircontrol)
        {
            if (crouch)
            {
                if (!wasCrouching)
                {
                    wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }
                move *= max_crouchSpeed;
                if(crounchDiseableCollider != null)
                {
                    crounchDiseableCollider.enabled = false;
                }
            }
            else
            {
                if(crounchDiseableCollider != null)
                {
                    crounchDiseableCollider.enabled = true;
                }

                if (wasCrouching)
                {
                    wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }
            
            Vector3 targetVelocity = new Vector2(move * 10f, player_rig.velocity.y);
            player_rig.velocity = Vector3.SmoothDamp(player_rig.velocity, targetVelocity, ref velocity, max_MoveSmooth);

            if(move > 0 && !facingRight)
            {
                Flip();
            }
            else if (move < 0 && facingRight)
            {
                Flip();
            }   
        }
        if(grounded && jump)
        {
            grounded = false;
            player_rig.AddForce(new Vector2(0f, max_JumpForce));
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}