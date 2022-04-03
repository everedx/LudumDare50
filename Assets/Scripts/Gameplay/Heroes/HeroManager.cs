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
    [SerializeField] private GameObject transitionObject;
    [SerializeField] private int levelsToShowAnimation = 5;
    [SerializeField] private float animDuration = 5.2f;

    private GameObject currentHero;
    private uint currentLevel;
    private bool showingShortcut = false;

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
            if (currentLevel % levelsToShowAnimation == 0 && !showingShortcut)
            {
                transitionObject.SetActive(true);
                Invoke("StartNewRound", animDuration);
                showingShortcut = true;
            }
            else if(!showingShortcut)
            {
                StartNewRound();
            }
        }
    }


    private void StartNewRound()
    {
        currentHero = Instantiate(heroPrefab);
        currentHero.GetComponent<ILeveable>().SetLevel(++currentLevel);
        showingShortcut = false;
    }
}
