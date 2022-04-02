using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAttack : MonoBehaviour, IAbility
{
    [SerializeField] float damage;
    [SerializeField] GameObject particlePrefab;

    public HeroBrain heroBrain;

    private void OnParticlesHit(object sender, System.EventArgs e)
    {
        heroBrain.Hit(damage);
    }

    void Start()
    {

    }

    public void DoDamage()
    {
        var heroBrain = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroBrain>();
        heroBrain.Hit(damage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
