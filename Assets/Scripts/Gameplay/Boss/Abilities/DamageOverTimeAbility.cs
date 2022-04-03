using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTimeAbility : MonoBehaviour, IAbility
{



    [SerializeField] float damagePerSecond;
    [SerializeField] float duration;
    [SerializeField] bool multiple;
    [SerializeField] GameObject particlePrefab;

    private List<GameObject> particlesReleased;
    // Start is called before the first frame update
    void Start()
    {
        particlesReleased = new List<GameObject>();

        if (multiple)
        {

            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Hero"))
            {
                HeroBrain brain = obj.GetComponent<HeroBrain>();

                brain.AddDOT(damagePerSecond, Mathf.FloorToInt(duration));

                particlesReleased.Add(Instantiate(particlePrefab, brain.transform.position + Utils.Vec2To3(Vector2.left * 0.2f), Quaternion.identity, brain.transform));
               
            }

        }
        else
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Hero");
            HeroBrain brain = obj.GetComponent<HeroBrain>();

            brain.AddDOT(damagePerSecond, Mathf.FloorToInt(duration));

            particlesReleased.Add(Instantiate(particlePrefab, brain.transform.position + Utils.Vec2To3(Vector2.left * 0.2f), Quaternion.identity,brain.transform));
            
        }

        Invoke("FinishDOT", duration);
    }


    private void FinishDOT()
    {
        foreach (GameObject go in particlesReleased)
            Destroy(go);
    }
}
