using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AbitiesUIPanel : MonoBehaviour
{
    [SerializeField] List<RectTransform> abitities;
    [SerializeField] Cursor marker;
    [SerializeField] Color selectedColor;
    [SerializeField] Color unselectedColor;

    private void Start()
    {
        
        marker.SelectionChanged += SelectionChangedHandler;
        marker.MarkOption(abitities[0]);
    }

    private void SelectionChangedHandler(RectTransform obj)
    {
        foreach (RectTransform rect in abitities)
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


    public void AbilityClicked(GameObject abilityPrefab)
    {
        ///Instan
    }
}
