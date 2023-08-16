using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class BasicGun : Weapon
    {
        [SerializeField]
        private Transform _shootPoint;

        public override void Equip()
        {
            _shootPoint.gameObject.SetActive(true);
            PlayerAnimator.PlayEquipRanged();
        }

        public override void Unequip()
        {
            _shootPoint.gameObject.SetActive(false);
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
