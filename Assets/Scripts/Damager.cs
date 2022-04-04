using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Damager : MonoBehaviour
{

    private float areaOfEffect;
    private int layerMask;
    private float damage;

    public void SetAreaOfEffect(float aoe, int layerMask, float damage)
    {
        areaOfEffect = aoe;
        this.layerMask = layerMask;
        this.damage = damage;
    }

    public void DoDamage()
    {
        List<Collider2D> colliders = Physics2D.OverlapCircleAll(transform.position, areaOfEffect, layerMask).ToList();

        foreach (Collider2D col in colliders)
        {
            col.GetComponent<HeroBrain>().Hit(damage);
        }

    }

}
