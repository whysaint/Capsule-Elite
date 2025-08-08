using System;
using UnityEditor.Rendering;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public Rigidbody _rb;
    public float Speed;

    private void Start()
    {
        Transform PlayerTransform = FindAnyObjectByType<PlayerHealth>().transform;
        Vector3 toPlayer = (PlayerTransform.position - transform.position).normalized;
        _rb.linearVelocity = toPlayer * Speed;
    }
}
