using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

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
    }

    private void OnDisable()
    {
        _inputs.Movement.Move.performed -= OnPlayerMovement;
        _inputs.Disable();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _currentVelocity * moveSpeed;
    }


    private void OnPlayerMovement(InputAction.CallbackContext inputContext)
    {
        _currentVelocity = inputContext.ReadValue<Vector2>();
    }
}