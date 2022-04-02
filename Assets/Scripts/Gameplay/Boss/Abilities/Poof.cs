using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poof : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var bossPos = GameObject.FindWithTag("Player").transform.Find("PoofLocation").transform.position;
        transform.position = bossPos;
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
