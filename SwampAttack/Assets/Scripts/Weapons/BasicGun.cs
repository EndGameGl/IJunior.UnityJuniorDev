using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class BasicGun : Weapon
    {
        [SerializeField]
        private Transform _shootPoint;

        [SerializeField]
        private Bullet _bulletPrefab;

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
            Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);
        }

        public override void Die()
        {
            PlayerAnimator.PlayDeathRanged();
        }
    }
}
