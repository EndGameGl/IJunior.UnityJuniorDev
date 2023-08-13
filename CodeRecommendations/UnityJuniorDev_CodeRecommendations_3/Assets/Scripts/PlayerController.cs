using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector2 _jumpVector;

    private Rigidbody2D _rigidbody;
    private PlayerInputs _inputs;
    private Vector2 _currentVelocity;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private readonly int _idleAnimationHash = Animator.StringToHash("BlobPlayer_Blue_Idle");
    private readonly int _walkAnimationHash = Animator.StringToHash("BlobPlayer_Blue_Walk");

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        _animator.Play(_walkAnimationHash);
        _inputs = new PlayerInputs();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_currentVelocity.x * _moveSpeed, _rigidbody.velocity.y);
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
        _currentVelocity = inputContext.ReadValue<Vector2>();

        if (_currentVelocity == Vector2.zero)
        {
            _animator.Play(_idleAnimationHash);
        }
        else
        {
            _animator.Play(_walkAnimationHash);
        }

        if (_currentVelocity.x < 0)
            _spriteRenderer.flipX = true;
        else if (_currentVelocity.x > 0)
            _spriteRenderer.flipX = false;
    }

    private void OnPlayerJump(InputAction.CallbackContext inputContext)
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        _rigidbody.AddForce(_jumpVector, ForceMode2D.Impulse);
    }
}