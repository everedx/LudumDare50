using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBrain : MonoBehaviour, ILeveable
{

    [SerializeField] float baseSpeed;
    [SerializeField] float baseAttackRange;
    [SerializeField] float baseAttackDamage;

    private float speed;
    private float attackRange;
    private float attackDamage;

    private Rigidbody2D rBody2D;
    private HeroAttack attackComponent;
    private Animator anim;
    private DamageableBase damageable;

    private bool movementEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        //for now
        speed = baseSpeed;
        attackRange = baseAttackRange;
        attackDamage = baseAttackDamage;

        rBody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        damageable = GetComponent<DamageableBase>();
        attackComponent = new HeroAttack(transform);

        rBody2D.velocity = Vector2.right * speed;

    }

    private void FixedUpdate()
    {
        if (movementEnabled)
        {
            if (rBody2D.velocity.x < speed)
            {
                rBody2D.velocity = Vector2.right *speed;
            }
        }
    }


    private void Update()
    {
        IDamageable damageable = attackComponent.IsSomethingInRange(attackRange);
        if (damageable != null)
        {
            movementEnabled = false;
            damageable.Damage(attackDamage); //For now, this... later this will be triggered by the animation
            //anim.SetTrigger("Attack");
        }
        else
        { 
            movementEnabled = true;
        }

    }

    public void SetLevel(uint level)
    {
        //TO DO
    }

    public void ChangeSpeed(float baseSpeedPct)
    {
        speed = baseSpeed * baseSpeedPct;
    }

    public void Hit(float damage)
    {
        damageable.Damage(damage);
    }
}
