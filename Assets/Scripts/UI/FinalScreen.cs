using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class FinalScreen:MonoBehaviour
{
    [SerializeField] List<LevelSummary> possibleSummaries;
    [SerializeField] HeroManager heroManager;
    [SerializeField] TextMeshProUGUI textLevel, textDifficulty, textTime;


    private void OnEnable()
    {
        uint level = heroManager.GetLevel();
        LevelSummary summary = GetSummary(level);
        textLevel.text = level.ToString();
        textDifficulty.text = summary.Description;
        textDifficulty.color = summary.Color;
        textTime.text = heroManager.GetTime().ToString() + "s";
    }

    private LevelSummary GetSummary(uint level)
    {
        LevelSummary summary = possibleSummaries[possibleSummaries.Count-1];

        foreach (LevelSummary sum in possibleSummaries)
        {
            if(sum.Level <= summary.Level && sum.Level > level)
                summary = sum;
        }

        return summary;
    }

    [Serializable]
    struct LevelSummary
    {
        public int Level;
        public string Description;
        public Color Color;
    }
}

