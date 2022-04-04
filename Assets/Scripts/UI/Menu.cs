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
    private bool pausedForBossDeath = false;

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
                Pause();
            }
            else
            {
                PlaySelected();
            }
        }
    }

    public void Pause(bool bossDead = false)
    {
        pausedForBossDeath = bossDead;
        paused = true;
        Time.timeScale = 0;
        heroManager.StopGame();

        foreach (Transform child in transform)
            child.gameObject.SetActive(true);

        actionsPanel.SetActive(false);
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
        if(pausedForBossDeath)
        {
            heroManager.Restart();
        }

        paused = false;
        heroManager.StartGame();
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);

        boss.SetActive (true);
        boss.GetComponent<BossBrain>().Restart();
        actionsPanel.SetActive(true);

        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
