using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBrain : DamageableBase
{
    private Animator animator;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
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
