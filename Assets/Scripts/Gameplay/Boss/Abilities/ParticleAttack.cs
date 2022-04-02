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

    private void OnParticlesHit(object sender, System.EventArgs e)
    {
        heroBrain.Hit(damage);
    }

    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Player");
        hero = GameObject.FindGameObjectWithTag("Hero");
        heroBrain = hero.GetComponent<HeroBrain>();

        //var particles = GameObject.Instantiate(particlePrefab);
        //particles.GetComponent<FlyingParticles>().ParticlesHit += OnParticlesHit;

        heroBrain.Hit(damage); // Hit at the start for testing
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
