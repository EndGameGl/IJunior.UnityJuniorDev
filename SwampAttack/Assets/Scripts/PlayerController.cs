using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Start()
    {
        _player.EquipWeapon(_player.Weapons[0]);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _player.CurrentEquippedWeapon.Use();
        }
    }
}
