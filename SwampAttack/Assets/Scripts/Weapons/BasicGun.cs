using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class BasicGun : Weapon
    {
        [SerializeField]
        private Transform _shootPoint;

        public override void Equip()
        {
            PlayerAnimator.PlayEquipRanged();
        }

        public override void Unequip()
        {

        }

        public override void Use()
        {
            PlayerAnimator.PlayRangedAttack();
        }

        public override void Die()
        {
            PlayerAnimator.PlayDeathRanged();
        }
    }
}
