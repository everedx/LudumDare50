using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LurkSpikes: MonoBehaviour, IAbility
{
    [SerializeField] GameObject spikeObject;
    [SerializeField] float damage = 25f;
    [SerializeField] float distanceBetweenSpikes=0.75f;
    [SerializeField] float timeBetweenSpikes = 0.1f;
    [SerializeField] float screenSizeInUnits = 20.0f;
    [SerializeField] Vector2 originOfSpikes;

    private List<GameObject> spikesReleased;
    


    private void Start()
    {
        spikesReleased = new List<GameObject>();

        int numberOfSpikes = Mathf.FloorToInt(screenSizeInUnits / distanceBetweenSpikes);

        StartCoroutine(CreateSpikes(numberOfSpikes));

        Invoke("FreeResources", 5);

    }

    private IEnumerator CreateSpikes(int numberOfSpikes)
    {
        int counter = 0;

        while (counter < numberOfSpikes)
        {
            GameObject go = Instantiate(spikeObject, Utils.Vec2To3(originOfSpikes) + Utils.Vec2To3(Vector2.left) * distanceBetweenSpikes * counter, Quaternion.identity);
            spikesReleased.Add(go);
            go.GetComponent<Damager>().SetAreaOfEffect(distanceBetweenSpikes / 2f, LayerMask.GetMask("Heroes"), damage);
            yield return new WaitForSeconds(timeBetweenSpikes);
            counter++;
        }

    }

    private void FreeResources()
    {
        foreach (GameObject go in spikesReleased)
        {
            Destroy(go);
        }
    }
}

