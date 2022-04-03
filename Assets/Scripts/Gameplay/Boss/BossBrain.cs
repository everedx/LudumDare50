using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBrain : DamageableBase
{
    [SerializeField] Menu menu;

    private Animator animator;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        DeathHappened += BossBrain_DeathHappened;
    }

    private void BossBrain_DeathHappened()
    {
        menu.Pause(bossDead: true);
    }

    public void Attack()
    {
        animator = GetComponent<Animator>();
        animator.Play("Casting");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
