using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 jumpVector;
    
    private Rigidbody2D _rigidbody;
    private PlayerInputs _inputs;

    private Vector2 _currentVelocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _inputs = new PlayerInputs();
    }

    private void OnEnable()
    {
        _inputs.Enable();
        _inputs.Movement.Move.performed += OnPlayerMovement;
        _inputs.Movement.Jump.performed += OnPlayerJump;
    }

    private void OnDisable()
    {
        _inputs.Movement.Move.performed -= OnPlayerMovement;
        _inputs.Movement.Jump.performed -= OnPlayerJump;
        _inputs.Disable();
    }
    
    private void OnPlayerMovement(InputAction.CallbackContext inputContext)
    {
        _rigidbody.velocity = inputContext.ReadValue<Vector2>() * moveSpeed;
    }
    
    private void OnPlayerJump(InputAction.CallbackContext inputContext)
    {
        _rigidbody.AddForce(new Vector2(_rigidbody.velocity.x, jumpVector.y), ForceMode2D.Impulse);
    }
}