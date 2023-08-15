using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private Player _player;

    private int _attackAnimationHash = Animator.StringToHash("PlayerAxeAttack");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();

        _player.Weapon.Equip();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _animator.Play(_attackAnimationHash);
            _player.Weapon.Use();
        }
    }
}
