using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Place Hero manager at the spawn position
 */
public class HeroManager : MonoBehaviour
{
    [SerializeField] private uint startingLevel;
    [SerializeField] private GameObject[] heroPrefabs;
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
        currentLevel++;

        int nHeroes = Mathf.Min((int)(((currentLevel - 1) / levelsToShowAnimation) + 1), heroPrefabs.Length);

        for(uint i = 0; i < nHeroes; i++)
        {
            currentHero = Instantiate(heroPrefabs[i]);
            currentHero.transform.Translate(new Vector2(-1 * i, 0));
            currentHero.GetComponent<ILeveable>().SetLevel(currentLevel - i * (uint)levelsToShowAnimation);
        }
        
        showingShortcut = false;
    }
}
