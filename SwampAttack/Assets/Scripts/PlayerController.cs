using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    private Animator _animator;

    private int _attackAnimationHash = Animator.StringToHash("PlayerAxeAttack");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _animator.Play(_attackAnimationHash);
        }
    }
}
