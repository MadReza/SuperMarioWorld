using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float MovementSpeed = 10;
    public float JumpForce = 10;

    Rigidbody2D rigidbody2d;
    Animator animator;
    SpriteRenderer spriteRenderer;

    //Animator Variables
    bool walking = false;

	void Start () {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
        Movement();
        UpdateAnimator();
	}

    void UpdateAnimator()
    {
        animator.SetBool("Walking", walking);
        animator.SetBool("Jumping", IsJumping());
        animator.SetBool("Falling", IsFalling());
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal == 0)
            walking = false;
        else
            walking = true;

        transform.position += new Vector3(horizontal, 0, 0) * MovementSpeed * Time.deltaTime;
        Flip(horizontal);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rigidbody2d.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }

    bool IsJumping()
    {
        return rigidbody2d.velocity.y > 0;
    }

    bool IsFalling()
    {
        return rigidbody2d.velocity.y < 0;
    }

    bool IsGrounded()
    {
        return rigidbody2d.velocity.y == 0;
    }

    void Flip(float direction)
    {
        if (direction == -1)    //left
        {
            spriteRenderer.flipX = true;
        }
        else if (direction == 1)    //right
        {
            spriteRenderer.flipX = false;
        }

    }
}
