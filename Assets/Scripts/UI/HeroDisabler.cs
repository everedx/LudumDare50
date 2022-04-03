using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDisabler : MonoBehaviour
{

    [SerializeField] List<HeroRepresentation> heroes;
    [SerializeField] HeroManager heroManager;

    private void OnEnable()
    {
        int numberOfHeroes = heroManager.GetNumberOfHeroes();
        numberOfHeroes += 1;
        foreach (HeroRepresentation repr in heroes)
        {
            if(repr.LevelToAppear <= numberOfHeroes)
                repr.Hero.SetActive(true);
            else
                repr.Hero.SetActive(false);
        }
    }

    [Serializable]
    private class HeroRepresentation
    {
        public GameObject Hero;
        public int LevelToAppear;
    }

}
