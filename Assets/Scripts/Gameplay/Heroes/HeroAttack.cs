using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack
{
    Transform transform;

    public HeroAttack(Transform transform)
    {
        this.transform = transform;
    }

    public IDamageable IsSomethingInRange(float range)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, LayerMask.GetMask("Player"));

        if (hit.transform !=null && hit.transform.TryGetComponent<IDamageable>(out IDamageable component))
            return component;
        return null;

    }
}
