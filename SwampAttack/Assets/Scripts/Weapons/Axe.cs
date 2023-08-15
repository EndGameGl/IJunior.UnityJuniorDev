using System;
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

        private bool _isHitting = false;

        [field: SerializeField]
        public override string WeaponAnimationName { get; protected set; }

        public override void Equip()
        {
            this.PlayerAnimator.PlayAxeEquipment();
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
            _collisionDetector.EnableCollisionDetection();
            yield return new WaitForSeconds(_collisionDuration);
            _collisionDetector.DisableCollisionDetection();
            _isHitting = false;
        }

        private void HandleCollision(GameObject target)
        {

        }
    }
}
