using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SlowDown : MonoBehaviour, IAbility
{
    [SerializeField] float slowSpeedPct;
    [SerializeField] float slowDuration;

    private List<GameObject> heroes;
    private GameObject boss;
    private List<HeroBrain> heroBrains;


    void Start()
    {
        heroBrains = new List<HeroBrain>();
        heroes = GameObject.FindGameObjectsWithTag("Hero").ToList();
        boss = GameObject.FindGameObjectWithTag("Player");
        transform.position = boss.transform.position  + Vector3.left * 5;


        foreach (GameObject hero in heroes)
        {
            heroBrains.Add(hero.GetComponent<HeroBrain>());
            hero.GetComponent<HeroBrain>().ChangeSpeed(slowSpeedPct);
        }

        Invoke("finishSlowing", slowDuration);
    }

    private void finishSlowing()
    {
        foreach (HeroBrain brain in heroBrains)
        {
            brain.ChangeSpeed(1);
        }
        Destroy(gameObject);
    }
}
