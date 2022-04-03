using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour, IAbility
{

    [SerializeField] bool multiple = false;
    [SerializeField] float stunDurationInSeconds = 3;
    [SerializeField] GameObject stunParticleObject;

    private GameObject boss;
    private List<HeroBrain> heroBrains;
    private List<GameObject> particlesReleased;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Player");

        heroBrains = new List<HeroBrain>();
        particlesReleased = new List<GameObject>();

        if (multiple)
        {

            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Hero"))
            {
                HeroBrain brain = obj.GetComponent<HeroBrain>();
                brain.SetStun(true);
                particlesReleased.Add(Instantiate(stunParticleObject, brain.transform.position + Utils.Vec2To3(Vector2.up) + Utils.Vec2To3(Vector2.left * 0.2f), Quaternion.identity)); 
                heroBrains.Add(brain);
            }

        }
        else
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Hero");
            HeroBrain brain = obj.GetComponent<HeroBrain>();
            brain.SetStun(true);
            particlesReleased.Add(Instantiate(stunParticleObject, brain.transform.position + Utils.Vec2To3(Vector2.up) + Utils.Vec2To3(Vector2.left * 0.2f), Quaternion.identity));
            heroBrains.Add(brain);
        }
        Invoke("FinishStun", stunDurationInSeconds);

    }

    private void FinishStun()
    {
        foreach (HeroBrain brain in heroBrains)
        {
            brain.SetStun(false);
            foreach(GameObject go in particlesReleased)
                Destroy(go);
        }
    }

}
