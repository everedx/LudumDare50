using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class AbitiesUIPanel : MonoBehaviour
{
    [SerializeField] List<LabeledAbility> abilities;
    [SerializeField] List<RectTransform> abilityLabels;
    [SerializeField] Cursor marker;
    [SerializeField] Color selectedColor;
    [SerializeField] Color unselectedColor;

    private void Start()
    {
        marker.SelectionChanged += SelectionChangedHandler;
        marker.MarkOption(abilityLabels[0]);

        RandomizeAbilities();
    }

    private void Update()
    {
        int index = -1;

        if (Controls.DownDown)
        {
            index = abilityLabels.IndexOf(marker.GetSelectedItem());
            VerticalSelection(index);

        }

        if (Controls.LeftDown)
        {
            index = abilityLabels.IndexOf(marker.GetSelectedItem());
            HorizontalSelection(index);
        }

        if (Controls.RightDown)
        {
            index = abilityLabels.IndexOf(marker.GetSelectedItem());
            HorizontalSelection(index);
        }

        if (Controls.UpDown)
        {
            index = abilityLabels.IndexOf(marker.GetSelectedItem());
            VerticalSelection(index);
        }

        if (Controls.SpaceDown)
        {
            AbilityClicked(marker.GetSelectedItem());
        }
    }

    private void VerticalSelection(int currentIndex)
    {
        switch (currentIndex)
        {
            case 0:
                marker.MarkOption(abilityLabels[1]);
                break;
            case 1:
                marker.MarkOption(abilityLabels[0]);
                break;
            case 2:
                marker.MarkOption(abilityLabels[3]);
                break;
            case 3:
                marker.MarkOption(abilityLabels[2]);
                break;
        }
    }
    private void HorizontalSelection(int currentIndex)
    {
        switch (currentIndex)
        {
            case 0:
                marker.MarkOption(abilityLabels[2]);
                break;
            case 1:
                marker.MarkOption(abilityLabels[3]);
                break;
            case 2:
                marker.MarkOption(abilityLabels[0]);
                break;
            case 3:
                marker.MarkOption(abilityLabels[1]);
                break;
        }
    }


    private void SelectionChangedHandler(RectTransform obj)
    {
        foreach (RectTransform rect in abilityLabels)
        {
            TextMeshProUGUI textComponent = rect.GetComponent<TextMeshProUGUI>();
            if(rect.Equals(obj))
                textComponent.color = selectedColor;
            else
                textComponent.color = unselectedColor;
        }
    }

    public void SelectionChangedPointer(RectTransform selectedObject)
    {
        marker.MarkOption(selectedObject);
    }

    

    public void AbilityClicked(RectTransform abilityPrefab)
    {
        abilityPrefab.GetComponent<AbilityContainer>().Use();
        RandomizeAbilities();
    }
    public void RandomizeAbilities()
    {
        var selectedAbilities = new Dictionary<string, GameObject>(); // Assuming label is unique

        while(selectedAbilities.Count < 4)
        {
            var r = Random.Range(0, 4);

            if (!selectedAbilities.ContainsKey(abilities[r].Label))
            {
                selectedAbilities.Add(abilities[r].Label, abilities[r].Prefab);
            }
        }

        int labelIndex = 0;
        foreach(var kvp in selectedAbilities)
        {
            abilityLabels[labelIndex].gameObject.GetComponent<TextMeshProUGUI>().text = kvp.Key;
            abilityLabels[labelIndex].gameObject.GetComponent<AbilityContainer>().abilityPrefab = kvp.Value;

            labelIndex++;
        }
    }

    private static class Controls
    {
        public static bool DownDown{ get => Input.GetButtonDown("S"); }
        public static bool DownUp{ get => Input.GetButtonUp("S"); }
        public static bool DownPressed{ get => Input.GetButton("S"); }


        public static bool UpDown { get => Input.GetButtonDown("W"); }
        public static bool UpUp { get => Input.GetButtonUp("W"); }
        public static bool UpPressed { get => Input.GetButton("W"); }


        public static bool LeftDown { get => Input.GetButtonDown("A"); }
        public static bool LeftUp { get => Input.GetButtonUp("A"); }
        public static bool LeftPressed { get => Input.GetButton("A"); }


        public static bool RightDown { get => Input.GetButtonDown("D"); }
        public static bool RightUp { get => Input.GetButtonUp("D"); }
        public static bool RightPressed { get => Input.GetButton("D"); }


        public static bool SpaceDown { get => Input.GetButtonDown("Space"); }
        public static bool SpaceUp { get => Input.GetButtonUp("Space"); }
        public static bool SpacePressed { get => Input.GetButton("Space"); }
    }
}

[Serializable]
public struct LabeledAbility
{
    public string Label;
    public GameObject Prefab;
}