using System.Linq;
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
        var initialWeapon = _player.Weapons.FirstOrDefault();
        if (initialWeapon is not null)
            _player.EquipWeapon(initialWeapon);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _player.CurrentEquippedWeapon?.Use();
        }
    }
}
