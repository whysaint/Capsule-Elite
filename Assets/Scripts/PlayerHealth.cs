using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 5;
    public int MaxHealth = 8;

    public AudioSource AddHealthSound;
    public HealthUI HealthUI;
    public UnityEvent UnityEventTakeDamage;
    
    private bool _invurnerable = false;

    private void Start()
    {
        HealthUI.Setup(MaxHealth);
        HealthUI.DisplayHealth(Health);
    }

    public void TakeDamage(int damageValue)
    {
        if (_invurnerable == false)
        {
            Health -= damageValue;
            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
        }
        _invurnerable = true;
        Invoke("StopInvurnerble", 1f);
        HealthUI.DisplayHealth(Health);
        UnityEventTakeDamage.Invoke();
    }


    public void StopInvurnerble()
    {
        _invurnerable = false;
    }
    public void AddHealht(int healthValue)
    {
        Health += healthValue;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
        AddHealthSound.Play();
        HealthUI.DisplayHealth(Health);
    }

    public void Die()
    {
        
    }
}
