using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IDamageable 
{
    /// <summary>
    /// Damages the object 
    /// </summary>
    /// <param name="damageAmount">Amount of damage</param>
    /// <returns>True if the attack was successful</returns>
    public bool Damage(float damageAmount);


    /// <summary>
    /// Heals the object
    /// </summary>
    /// <param name="healAmount">Amount of heal</param>
    public void Heal(float healAmount);
}
