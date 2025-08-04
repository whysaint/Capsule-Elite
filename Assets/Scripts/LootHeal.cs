using System;
using UnityEngine;

public class LootHeal : MonoBehaviour
{
    public int HealthValue = 1;
    private void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody.GetComponent<PlayerHealth>().AddHealht(HealthValue);
        Destroy(gameObject);
    }
}
