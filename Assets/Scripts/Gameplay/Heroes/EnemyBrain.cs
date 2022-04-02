using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour, ILeveable
{

    [SerializeField] float baseSpeed;
    [SerializeField] float baseAttackRange;
    [SerializeField] float baseAttackDamage;

    private float speed;
    private float attackRange;
    private float attackDamage;

    private Rigidbody2D rBody2D;
    private EnemyAttack attackComponent;
    private Animator anim;

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
        attackComponent = new EnemyAttack(transform);

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
}
