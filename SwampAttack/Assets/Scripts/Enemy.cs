using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : MonoBehaviour
    {
        [field: SerializeField]
        public int MaxHealth { get; private set; }

        [field: SerializeField]
        public int Health { get; private set; }

        [field: SerializeField]
        public int Reward { get; private set; }

        [SerializeField]
        private Player _target;

        public event Action OnEnemyDeath;

        public void TakeDamage(int amount)
        {
            Health -= amount;
        }
    }
}
