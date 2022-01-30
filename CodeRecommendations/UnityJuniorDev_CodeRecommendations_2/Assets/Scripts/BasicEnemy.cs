using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BasicEnemy : MonoBehaviour
{
    private Transform _targetTransform;
    
    [SerializeField] private float speed;

    public void SetTarget(Transform targetTransform)
    {
        _targetTransform = targetTransform;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position, 
            _targetTransform.position, 
            Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent<TargetDummy>(out _))
        {
            gameObject.SetActive(false);
        }
    }
}