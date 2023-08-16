using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private readonly int _playerIdleMeleeHash = Animator.StringToHash("PlayerIdle");
        private readonly int _playerIdleGunHash = Animator.StringToHash("PlayerIdleGun");
        private readonly int _playerMeleeAttack = Animator.StringToHash("PlayerAxeAttack");
        private readonly int _playerRangedAttack = Animator.StringToHash("PlayerGunShoot");
        private readonly int _playerEquipMelee = Animator.StringToHash("PlayerGunToAxe");
        private readonly int _playerEquipRanged = Animator.StringToHash("PlayerAxeToGun");
        private readonly int _playerDeathMelee = Animator.StringToHash("PlayerDeathAxe");
        private readonly int _playerDeathRanged = Animator.StringToHash("PlayerDeathGun");

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayMeleeEquipment()
        {
            _animator.Play(_playerEquipMelee);
        }

        public void PlayMeleeDeath()
        {
            _animator.Play(_playerDeathMelee);
        }

        public void PlayMeleeAttack()
        {
            _animator.Play(_playerMeleeAttack);
        }

        public void PlayRangedAttack()
        { 
            _animator.Play(_playerRangedAttack);
        }

        public void PlayEquipRanged() 
        {
            _animator.Play(_playerEquipRanged);
        }

        public void PlayDeathRanged()
        {
            _animator.Play(_playerDeathRanged);
        }
    }
}
