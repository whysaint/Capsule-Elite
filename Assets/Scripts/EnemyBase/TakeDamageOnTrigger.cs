using System;
using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    public EnemyHealth EnemyHealth;

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth.TekeDamage(1);
    }
}
