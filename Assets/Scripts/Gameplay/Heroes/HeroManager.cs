using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/**
 * Place Hero manager at the spawn position
 */
public class HeroManager : MonoBehaviour
{
    [SerializeField] private uint startingLevel;
    [SerializeField] private BossBrain boss;
    [SerializeField] private GameObject[] heroPrefabs;
    [SerializeField] private GameObject transitionObject;
    [SerializeField] private int levelsToShowAnimation = 5;
    [SerializeField] private float animDuration = 5.2f;

    private List<GameObject> currentHeroes;
    private uint currentLevel;
    private bool showingShortcut = false;

    private bool started;

    // Start is called before the first frame update
    void Start()
    {
        currentHeroes = new List<GameObject>();
        currentLevel = startingLevel - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            return;
        }

        if (currentHeroes.All(x => x == null)) 
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
        boss.ResetHealth();

        currentLevel++;
        
        int nHeroes = Mathf.Min((int)(((currentLevel - 1) / levelsToShowAnimation) + 1), heroPrefabs.Length);

        currentHeroes = new List<GameObject>();

        for(uint i = 0; i < nHeroes; i++)
        {
            var newHero = Instantiate(heroPrefabs[i]);
            newHero.transform.Translate(new Vector2(-1 * i, 0));
            newHero.GetComponent<ILeveable>().SetLevel(currentLevel - i * (uint)levelsToShowAnimation);

            currentHeroes.Add(newHero);
        }
        
        showingShortcut = false;
    }

    public int GetNumberOfHeroes()
    {
        return Mathf.Min((int)(((Mathf.Clamp(currentLevel,0,float.PositiveInfinity) - 1) / levelsToShowAnimation) + 1), heroPrefabs.Length);
    }

    public void Restart()
    {
        currentHeroes.ForEach(x =>
        {
            if (x != null) Destroy(x);
        });

        Start();

        boss.ResetHealth();
    }

    public void StartGame()
    {
        started = true;
    }

    public void StopGame()
    {
        started = false;
    }
}
