using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody _rb;
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public float MaxSpeed;
    
    public bool isGround;

    public Transform CollisionPlayer;
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || isGround == false)
        {
            CollisionPlayer.localScale = Vector3.Lerp(CollisionPlayer.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 15f);
        }
        else
        {
            CollisionPlayer.localScale = Vector3.Lerp(CollisionPlayer.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 15f);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            if (isGround)
            {
                _rb.AddForce(0f, JumpSpeed, 0f, ForceMode.VelocityChange);
            }
        }
    }

    private void FixedUpdate()
    { 
        float stabilFrictionSpeed = 1.0f;
        
        if (isGround == false)
        {
            stabilFrictionSpeed = 0.1f;
            
            if (_rb.linearVelocity.x > MaxSpeed && Input.GetAxis("Horizontal") > 0)
            {
                stabilFrictionSpeed = 0f;
            }
        
            if (_rb.linearVelocity.x < -MaxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                stabilFrictionSpeed = 0f;
            }
        }
        _rb.AddForce(Input.GetAxis("Horizontal") * MoveSpeed * stabilFrictionSpeed, 0f, 0f, ForceMode.VelocityChange);

        if (isGround)
        {
            _rb.AddForce(-_rb.linearVelocity.x * Friction, 0f, 0f, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionStay(Collision other)
    {

        for (int i = 0; i < other.contactCount; i++)
        {
            float angel = Vector3.Angle(other.contacts[i].normal, Vector3.up);
            if (angel < 45f)
            {
                isGround = true;
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        isGround = false;
    }
}
