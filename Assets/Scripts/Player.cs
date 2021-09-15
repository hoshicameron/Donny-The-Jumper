using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce=11f;


    private Rigidbody2D rigidbody2D;
    private Animator animator;

    private bool isGrounded = true;
    private float movementX;
    private int groundLayer;
    private int enemyLayer;

    private static readonly int Walking = Animator.StringToHash("walking");

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = transform.GetChild(0).GetComponent<Animator>();

        groundLayer = LayerMask.NameToLayer("Obstacle");
        enemyLayer = LayerMask.NameToLayer("Enemy");

    }

    private void Update()
    {
        KeyboardInput();
        AnimatePlayer();
        PlayerDirection();

    }

    //Flip player to face move direction
    private void PlayerDirection()
    {
        if (movementX > 0)
            transform.localScale = Vector3.one;
        else if(movementX < 0)
            transform.localScale= new Vector3(-1, 1, 1);
    }

    private void KeyboardInput()
    {
        movementX = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (rigidbody2D == null) return;

        float xForce = movementX * moveForce * Time.fixedDeltaTime;

        Vector2 force=new Vector2(xForce,rigidbody2D.velocity.y);
        rigidbody2D.velocity = force;

        PlayerJump();

    }

    // Push the player up
    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            rigidbody2D.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        }
    }

    private void AnimatePlayer()
    {
        if (Math.Abs(movementX) > Mathf.Epsilon)
        {
            animator.SetBool(Walking,true);
        } else
        {
            animator.SetBool(Walking,false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == groundLayer)
        {
            isGrounded = true;
        }

        if (other.gameObject.layer == enemyLayer)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == enemyLayer)
        {
            Destroy(gameObject);
        }
    }
}
