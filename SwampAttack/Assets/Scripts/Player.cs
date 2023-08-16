using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField]
    public int Health { get; private set; }

    [field: SerializeField]
    public List<Weapon> Weapons { get; private set; }

    [field: SerializeField]
    public Weapon CurrentEquippedWeapon { get; private set; }

    public void EquipWeapon(Weapon weapon)
    {
        CurrentEquippedWeapon = weapon;
        weapon.enabled = true;
        weapon.Equip();

        foreach (var item in Weapons.Where(x => x != weapon))
        {
            item.Unequip();
            item.enabled = false;
        }
    }
}
