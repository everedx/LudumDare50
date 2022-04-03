using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Notificator : MonoBehaviour
{
    TextMeshProUGUI textComponent;

    // Start is called before the first frame update
    void Awake()
    {
        textComponent = GetComponentInChildren<TextMeshProUGUI>();
    }


    public void SetNotifText(string text)
    {
        textComponent.text = text;
    }

}
