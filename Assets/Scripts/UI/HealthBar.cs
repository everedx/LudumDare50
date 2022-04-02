using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image healthBarUI;
    [SerializeField] DamageableBase damageableComponent;

    private float maxHealth;

    void Start()
    {
        maxHealth = damageableComponent.GetMaxHealth();
        damageableComponent.HealthChanged += AdjustHealhBar;
        damageableComponent.DeathHappened += DeathHandler;
        AdjustHealhBar(damageableComponent.GetCurrentHealth());
    }

    private void DeathHandler()
    {
        Debug.Log("The character " + damageableComponent.transform.name + " died." );
    }

    private void AdjustHealhBar(float newHealth)
    {
        float percentage = newHealth / maxHealth;

        healthBarUI.fillAmount = percentage;

    }
}
