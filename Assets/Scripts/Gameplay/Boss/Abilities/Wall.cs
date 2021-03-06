using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : DamageableBase, IAbility
{
    private const float playerOffset = 1.5f;
    private const float maxWallPos = 5.5f;

    

    // Start is called before the first frame update
    void Start()
    {
        var hPos = GameObject.FindWithTag("Hero").transform.position + Utils.Vec2To3(Vector2.up * 1.1f);

        var xPos = Mathf.Min(hPos.x + playerOffset, maxWallPos);
        transform.position = new Vector2(xPos, hPos.y);

        DeathHappened += WallDeathHappened;

        base.Start();
    }

    private void WallDeathHappened()
    {
        //Destroy(gameObject);
        GetComponent<Animator>().SetTrigger("Destroy");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
