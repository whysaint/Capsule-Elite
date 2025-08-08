using System;
using UnityEngine;

public class TakeDamageOnColission : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public bool DieOnAnyCollisioon;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.rigidbody)
        {
            if (other.rigidbody.GetComponent<Bullet>())
            {
                EnemyHealth.TekeDamage(1);
            }
        }

        if (DieOnAnyCollisioon)
        {
            EnemyHealth.TekeDamage(1000);
        }
    }
}
