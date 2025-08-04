using System;
using UnityEngine;

public class TakeDamageOnColission : MonoBehaviour
{
    public EnemyHealth EnemyHealth;

    private void OnCollisionEnter(Collision other)
    {
        if (other.rigidbody)
        {
            if (other.rigidbody.GetComponent<Bullet>())
            {
                EnemyHealth.TekeDamage(1);
            }
        }
    }
}
