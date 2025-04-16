using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private Vector2 movementInput;
    private Vector2 movement;
    private float speed = 10;
    public Animator animator;
    private Vector2 lastMoveDir;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        movement = movementInput * speed * Time.fixedDeltaTime;
        //transform.Translate(movement);
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        if (movement != Vector2.zero)
        {
            lastMoveDir = movement;
        }

        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
        animator.SetBool("IsMoving", movement != Vector2.zero);
    }

    public void OnMovement(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }
}
