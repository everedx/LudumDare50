using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Place Hero manager at the spawn position
 */
public class HeroManager : MonoBehaviour
{
    [SerializeField] private uint startingLevel;
    [SerializeField] private GameObject heroPrefab;

    private GameObject currentHero;
    private uint currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = startingLevel - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHero == null)
        {
            currentHero = Instantiate(heroPrefab);
            currentHero.GetComponent<ILeveable>().SetLevel(++currentLevel);
        }
    }
}
