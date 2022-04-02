using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingParticles : MonoBehaviour
{
    public event EventHandler ParticlesHit;

    // Start is called before the first frame update
    void Start()
    {
        ParticlesHit?.Invoke(this, null); // TODO: Do this when particles actually hit. Trigger only once?
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
