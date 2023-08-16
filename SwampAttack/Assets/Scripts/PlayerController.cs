using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private Player _player;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    private void Start()
    {
        _player.Weapon.Equip();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _player.Weapon.Use();
        }
    }
}
