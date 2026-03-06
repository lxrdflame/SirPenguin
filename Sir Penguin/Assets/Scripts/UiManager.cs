using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiManager : MonoBehaviour
{
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private List<GameObject> FirstSelectButton;
    [SerializeField] private GameObject pausepanel, controlsPanel;
    [SerializeField] private List<GameObject> ButtonResets;
    public void OnPauseMenu()
    {
        if (pausepanel.activeSelf)
        {
            pausepanel.SetActive(false);
            Time.timeScale = 1f;

        }
        else
        {
            pausepanel.SetActive(true);
            eventSystem.firstSelectedGameObject = FirstSelectButton[0];
            Time.timeScale = 0f;
        }
    }

    public void OnControlsPanel()
    {
        if (controlsPanel.activeSelf)
        {
            controlsPanel.SetActive(false);
            eventSystem.firstSelectedGameObject = FirstSelectButton[0];

        }
        else
        {
            controlsPanel.SetActive(true);
            eventSystem.firstSelectedGameObject = FirstSelectButton[1];

        }
    }

    public void OnResumegame()
    {
        pausepanel.SetActive(false);
        Time.timeScale = 1f;


    }

    void Update()
    {
        if (eventSystem.currentSelectedGameObject != null)
        {
            if (eventSystem.currentSelectedGameObject.name == "HpSlider")
            {
                eventSystem.SetSelectedGameObject(ButtonResets[0]);
            }
            else if (eventSystem.currentSelectedGameObject.name == "Stamina Slider")
            {
                eventSystem.SetSelectedGameObject(ButtonResets[1]);
            }


        }
    }

}
