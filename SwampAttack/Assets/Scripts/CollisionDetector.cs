using System;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class CollisionDetector : MonoBehaviour
    {
        private BoxCollider2D _collider;

        public event Action<GameObject> OnCollisionEnter;

        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();
            DisableCollisionDetection();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnCollisionEnter?.Invoke(collision.gameObject);
        }

        public void EnableCollisionDetection() { _collider.enabled = true; }

        public void DisableCollisionDetection() { _collider.enabled = false; }
    }
}
