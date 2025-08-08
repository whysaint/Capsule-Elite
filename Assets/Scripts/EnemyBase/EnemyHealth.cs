using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 1;
    public UnityEvent UnityEventTekeDamage;

    public void TekeDamage(int damageValue)
    {
        UnityEventTekeDamage.Invoke();
        Health -= damageValue;
        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
