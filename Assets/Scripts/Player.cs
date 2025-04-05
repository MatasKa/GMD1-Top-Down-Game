using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    private Vector2 movement;
    private float speed = 3;
    public Animator animator;
    private Vector2 moveInput;
    private Vector2 lastMoveDir;

    void Update()
    {
        transform.Translate(movement);

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
        movement = value.Get<Vector2>() * Time.deltaTime * speed;
    }
}
