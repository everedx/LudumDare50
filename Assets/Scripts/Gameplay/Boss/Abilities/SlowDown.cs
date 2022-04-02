using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour, IAbility
{
    [SerializeField] float slowSpeedPct;
    [SerializeField] float slowDuration;

    public GameObject hero;
    public HeroBrain heroBrain;

    public void Use()
    {
        heroBrain.ChangeSpeed(slowSpeedPct);
        Invoke("finishSlowing", slowDuration);
    }

    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        heroBrain = hero.GetComponent<HeroBrain>();
    }

    private void finishSlowing()
    {
        heroBrain.ChangeSpeed(1);
    }
}
