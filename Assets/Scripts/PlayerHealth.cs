using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 5;
    public int MaxHealth = 8;
    public AudioSource TakeDamageSound;
    public AudioSource AddHealthSound;

    public HealthUI HealthUI;

    public DamageScreen DamageScreen;

    public Blink Blink;
    
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
        TakeDamageSound.Play();
        HealthUI.DisplayHealth(Health);
        DamageScreen.StartEffect();
        Blink.StartBlink();
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
