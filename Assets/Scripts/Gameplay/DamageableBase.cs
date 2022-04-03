using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableBase : MonoBehaviour, IDamageable
{
    [SerializeField] public float startingHealth;
    [SerializeField] private DamageableType type;

    private float currentHealth;

    //Changed health event
    public event Action<float> HealthChanged;
    public event Action DeathHappened;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentHealth = startingHealth;
    }

    public bool Damage(float damageAmount)
    {
        float prevHealth = currentHealth;
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);
        if(prevHealth != currentHealth)
            HealthChanged?.Invoke(currentHealth);
        if (currentHealth == 0 && prevHealth != 0)
            DeathHappened?.Invoke();

        return true;    //for now, all attacks are successful.
    }

    public void Heal(float healAmount)
    {
        float prevHealth = currentHealth;
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);
        if (prevHealth != currentHealth)
            HealthChanged?.Invoke(currentHealth);
    }

    public float GetMaxHealth()
    {
        return startingHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void ResetHealth()
    {
        ResetHealth(startingHealth);
    }

    public void ResetHealth(float health)
    {
        float prevHealth = currentHealth;

        currentHealth = health;
        startingHealth = health;

        if (prevHealth != currentHealth)
            HealthChanged?.Invoke(currentHealth);
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}

public enum DamageableType
{
    PlayerObjects,
    EnemyObjects
}
