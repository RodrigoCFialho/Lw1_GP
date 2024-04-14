using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CustomInputs customInput;

    private Rigidbody2D myRigidBody;

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        customInput = CustomInputManager.Instance.customInputsBindings;

        customInput.Player.Movement.performed += InputMovementPerformed;
        customInput.Player.Movement.canceled += InputMovementCancelled;
    }

    private void OnDisable()
    {
        customInput.Player.Movement.performed -= InputMovementPerformed;
        customInput.Player.Movement.canceled -= InputMovementCancelled;
    }

    private void InputMovementPerformed(InputAction.CallbackContext context)
    {
        //tenho fome
    }

    private void InputMovementCancelled(InputAction.CallbackContext context)
    {
        
    }
}
