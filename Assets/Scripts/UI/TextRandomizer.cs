using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextRandomizer : MonoBehaviour
{

    [SerializeField] private List<string> possibleDialogs;

    private TextMeshProUGUI textComponent;
    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.text = possibleDialogs[Random.Range(0, possibleDialogs.Count)];
    }


    private void OnEnable()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.text = possibleDialogs[Random.Range(0, possibleDialogs.Count)];
    }
}
