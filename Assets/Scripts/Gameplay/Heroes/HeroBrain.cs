using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeroBrain : MonoBehaviour, ILeveable
{
    [SerializeField] float baseSpeed;
    [SerializeField] float baseAttackRange;
    [SerializeField] float baseAttackDamage;
    [SerializeField] float speedIncreasePerLevel;
    [SerializeField] float damageIncreasePerLevel;
    [SerializeField] float healthIncreasePerLevel;

    private float speedModifier = 1;
    private float speed { get { return (baseSpeed + level * speedIncreasePerLevel) * speedModifier; } }
    private float attackDamage { get { return baseAttackDamage * damageIncreasePerLevel; } }
    private float attackRange;

    private uint level;

    private Rigidbody2D rBody2D;
    private HeroAttack attackComponent;
    private Animator anim;
    private DamageableBase damageable;

    private bool movementEnabled = true;
    private bool stunned = false;

    // Start is called before the first frame update
    void Start()
    {
        //for now
        attackRange = baseAttackRange;

        rBody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        damageable = GetComponent<DamageableBase>();
        damageable.ResetHealth(damageable.startingHealth + healthIncreasePerLevel * level);
        attackComponent = new HeroAttack(transform);

        rBody2D.velocity = Vector2.right * speed;

    }

    private void FixedUpdate()
    {
        if (movementEnabled)
        {
            if (stunned)
                rBody2D.velocity = Vector2.zero;
            else
            {
                if (rBody2D.velocity.x < speed)
                {
                    rBody2D.velocity = Vector2.right * speed;
                }
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
        this.level = level;
        GetComponentInChildren<TextMeshProUGUI>().text = "lvl. " + this.level;
    }

    public void ChangeSpeed(float speedPct)
    {
        speedModifier = speedPct;
    }

    public void SetStun(bool status)
    {
        stunned = status;
    }

    public void Hit(float damage)
    {
        damageable.Damage(damage);

        if(damageable.IsDead())
        {
            Destroy(gameObject);
        }
    }
}
