using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce=11f;
    [SerializeField] private float maxVelocity = 22f;

    private Rigidbody2D rigidbody2D;
    private Animator animator;

    private float movementX;
    private static readonly int Walking = Animator.StringToHash("walking");

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    private void Update()
    {
        KeyboardInput();
        AnimatePlayer();
        PlayerDirection();
        print(movementX);
    }

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
        if (rigidbody2D != null)
        {
            float xForce = movementX * moveForce * Time.fixedDeltaTime;
            Vector2 force=new Vector2(xForce,rigidbody2D.velocity.y);

            rigidbody2D.velocity = force;

            if (Input.GetButtonDown("Jump"))
            {

                rigidbody2D.AddForce(Vector2.up*jumpForce);
            }
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
}
