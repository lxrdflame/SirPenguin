using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject confirmationPanel;
    public GameObject controlsPanel;
    [SerializeField] private EventSystem eventSystem;
    public GameObject tickGameObject;
    public GameObject closeGameObject;
    public GameObject startGameObject;
    public GameObject[] buttons;

    public void OnClickStart()
    {
        confirmationPanel.SetActive(true);
        eventSystem.SetSelectedGameObject(tickGameObject);

        for (int i = 0; i < buttons.Length; i++) { 
            buttons[i].SetActive(false);
        }

        
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void OnClickControls()
    {
        controlsPanel.SetActive(true);
        eventSystem.SetSelectedGameObject(closeGameObject);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }

    public void OnClickTick()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void OnClickX()
    {
        SceneManager.LoadScene("FreeForAll");
    }

    public void OnClickClosePanel()
    {
        controlsPanel.SetActive(false);
        eventSystem.SetSelectedGameObject(startGameObject);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }
    }

    public void OnClickBack()
    {
        confirmationPanel.SetActive(false);
        eventSystem.SetSelectedGameObject(startGameObject);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }
    }
}
