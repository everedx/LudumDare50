using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabler : MonoBehaviour
{

    public bool disableRequested;
    private void Start()
    {
        disableRequested = false;
    }

    private void Update()
    {
        if(disableRequested)
            gameObject.SetActive(false);
    }

}
