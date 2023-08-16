using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [field: SerializeField]
        public int Damage { get; private set; }

        [field: SerializeField]
        public float Speed { get; private set; }

        [SerializeField]
        private float _baseLifetime;

        private float _currentLifetime;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _currentLifetime += Time.fixedDeltaTime;

            if (_currentLifetime >= _baseLifetime)
            {
                Destroy(this.gameObject);
            }

            var currentPosition = _rigidbody.position;
            currentPosition += Speed * Time.fixedDeltaTime * Vector2.left;
            _rigidbody.MovePosition(currentPosition);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<Enemy>(out var enemy))
            {
                enemy.TakeDamage(Damage);
                Destroy(this.gameObject);
            }
        }
    }
}
