using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour, IAbility
{
    [SerializeField] float slowSpeedPct;
    [SerializeField] float slowDuration;

    public GameObject player;
    public EnemyBrain enemyBrain;

    public void Use()
    {
        enemyBrain.ChangeSpeed(slowSpeedPct);
        Invoke("finishSlowing", slowDuration);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Hero");
        enemyBrain = player.GetComponent<EnemyBrain>();
    }

    private void finishSlowing()
    {
        enemyBrain.ChangeSpeed(1);
    }
}
