using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Health;

    public void TekeDamage(int damageValue)
    {
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
