using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Axe : Weapon
    {
        [SerializeField]
        private CollisionDetector _collisionDetector;

        [SerializeField]
        private float _collisionDuration;

        [field: SerializeField]
        public override string WeaponAnimationName { get; protected set; }

        [SerializeField]
        private int _damage;

        private bool _isHitting = false;

        public override void Equip()
        {
            PlayerAnimator.PlayMeleeEquipment();
            _collisionDetector.OnCollisionEnter += HandleCollision;
        }

        public override void Unequip()
        {
            _collisionDetector.OnCollisionEnter -= HandleCollision;
        }

        public override void Use()
        {
            if (_isHitting == false)
            {
                StartCoroutine(Hit());
            }
        }

        private IEnumerator Hit()
        {
            _isHitting = true;
            PlayerAnimator.PlayMeleeAttack();
            _collisionDetector.EnableCollisionDetection();
            yield return new WaitForSeconds(_collisionDuration);
            _collisionDetector.DisableCollisionDetection();
            _isHitting = false;
        }

        private void HandleCollision(GameObject target)
        {
            if (target.TryGetComponent<Enemy>(out var enemy))
            {
                enemy.ApplyDamage(_damage);
            }
        }
    }
}
