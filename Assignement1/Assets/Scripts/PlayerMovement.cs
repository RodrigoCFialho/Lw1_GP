using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    private Animator myAnimator;

    [SerializeField]
    private float speed = 3f;

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    public void EnableMovementEvent(Vector2 moveInput)
    {
        if (moveInput.x != 0 && moveInput.y == 0 || moveInput.y != 0 && moveInput.x == 0 || moveInput == Vector2.zero)
        {
            myRigidBody.velocity = moveInput * speed;
        }
        SetMovementOnAnimator();
    }

    private void SetMovementOnAnimator()
    {
        myAnimator.SetFloat("VelocityX", myRigidBody.velocity.x);
        myAnimator.SetFloat("VelocityY", myRigidBody.velocity.y);

    }
}
