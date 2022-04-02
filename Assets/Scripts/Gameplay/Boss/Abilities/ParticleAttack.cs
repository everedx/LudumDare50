using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAttack : MonoBehaviour, IAbility
{
    [SerializeField] float damage;
    [SerializeField] GameObject particlePrefab;

    public GameObject boss;
    public GameObject hero;
    public HeroBrain heroBrain;

    public void Use()
    {
        var particles = GameObject.Instantiate(particlePrefab);
        particles.GetComponent<FlyingParticles>().ParticlesHit += OnParticlesHit;
    }

    private void OnParticlesHit(object sender, System.EventArgs e)
    {
        heroBrain.
    }

    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Player");
        hero = GameObject.FindGameObjectWithTag("Hero");
        heroBrain = hero.GetComponent<HeroBrain>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
