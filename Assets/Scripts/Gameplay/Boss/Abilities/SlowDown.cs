using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour, IAbility
{
    [SerializeField] float slowSpeedPct;
    [SerializeField] float slowDuration;

    private GameObject hero;
    private HeroBrain heroBrain;


    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        heroBrain = hero.GetComponent<HeroBrain>();
        transform.position = hero.transform.position;

        heroBrain.ChangeSpeed(slowSpeedPct);
        Invoke("finishSlowing", slowDuration);
    }

    private void finishSlowing()
    {
        heroBrain.ChangeSpeed(1);
    }
}
