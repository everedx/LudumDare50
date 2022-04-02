using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poof : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var bossPos = GameObject.FindWithTag("Player").transform.position;
        transform.position = bossPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
