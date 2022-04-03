using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] Color selectedColor;
    [SerializeField] Color unselectedColor;
    [SerializeField] RectTransform[] rects;
    [SerializeField] GameObject boss;
    [SerializeField] GameObject actionsPanel;
    [SerializeField] HeroManager heroManager;

    private bool paused;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                paused = true;
                Time.timeScale = 0;
                heroManager.StopGame();

                foreach (Transform child in transform)
                    child.gameObject.SetActive(true);

                actionsPanel.SetActive(false);
            }
            else
            {
                PlaySelected();
            }
        }
    }

    public void SelectionChangedHandler(RectTransform obj)
    {
        foreach (RectTransform rect in rects)
        {
            TextMeshProUGUI textComponent = rect.GetComponent<TextMeshProUGUI>();
            if (rect.Equals(obj))
                textComponent.color = selectedColor;
            else
                textComponent.color = unselectedColor;
        }

        //aSource.PlayOneShot(audioSelect);
    }

    public void ExitSelected()
    {
        Application.Quit();
    }

    public void PlaySelected()
    {
        paused = false;
        heroManager.StartGame();
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);

        boss.SetActive (true);
        actionsPanel.SetActive(true);

        Time.timeScale = 1;
    }
}
