using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyPatrol : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        [SerializeField]
        private Transform _groundDetector;

        [SerializeField]
        private float _groundCheckLength;

        private Rigidbody2D _rigidBody;
        private int _direction = -1;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rigidBody.velocity = new Vector2(Vector2.right.x * _speed * _direction * Time.fixedDeltaTime, _rigidBody.velocity.y);

            var groundInfo = Physics2D.Raycast(_groundDetector.position, Vector2.down, _groundCheckLength);

            if (groundInfo.collider is null)
            {
                _direction *= -1;
                transform.Rotate(new Vector3(0, 180, 0));
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerController>(out var player))
            {
                Debug.Log("Hit player");
            }
        }
    }
}
