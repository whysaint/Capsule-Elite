using System;
using UnityEngine;

public class Hen : MonoBehaviour
{
    public Rigidbody _rb;
    public float speed = 3f;
    public float TimeToReachSpeed = 1f;
    
    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = FindAnyObjectByType<PlayerHealth>().transform;
    }

    private void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = _rb.mass * (toPlayer * speed - _rb.linearVelocity) / TimeToReachSpeed;
        _rb.AddForce(force);
    }
}
