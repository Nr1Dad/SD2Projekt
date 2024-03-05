using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    // Skal f�rst bruges ved animation
    //private SpriteRenderer sprite;
    //private Animator anim;
    [SerializeField] private LayerMask jumpableGround;  

    private float dirX = 0f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float moveSpeed = 7f;

    private enum MovementState {idle, running, jumping, falling }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

        // Skal f�rst bruges ved animation
        //sprite = GetComponent<SpriteRenderer>();
        //anim = GetComponent<Animator>();
    }

    private void Start()
    {
        
    }

    
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (dirX * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded()) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        //Methode til at �ndre animations
        //UpdateAnimationState();
    }

    //Methode til at �ndre animations
    /*private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }

        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }

        if (rb.velocity.y < .1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }*/

   private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
