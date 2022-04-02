using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour, IAbility
{
    [SerializeField] float slowSpeedPct;
    [SerializeField] float slowDuration;

    private GameObject hero;
    private HeroBrain heroBrain;

    public void Use()
    {
        heroBrain.ChangeSpeed(slowSpeedPct);
        Invoke("finishSlowing", slowDuration);
    }

    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        heroBrain = hero.GetComponent<HeroBrain>();
        transform.position = hero.transform.position;
    }

    private void finishSlowing()
    {
        heroBrain.ChangeSpeed(1);
    }
}
