using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BasicEnemy : MonoBehaviour
{ 
    [SerializeField] private float _speed;
    
    private Transform _targetTransform;

    public void SetTarget(Transform targetTransform)
    {
        _targetTransform = targetTransform;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position, 
            _targetTransform.position, 
            Time.deltaTime * _speed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent<TargetDummy>(out _))
        {
            gameObject.SetActive(false);
        }
    }
}