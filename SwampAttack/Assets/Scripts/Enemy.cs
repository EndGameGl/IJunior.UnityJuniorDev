using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Enemy : MonoBehaviour
    {
        [field: SerializeField]
        public int Health { get; private set; }

        public void ApplyDamage(int amount)
        {

        }
    }
}
