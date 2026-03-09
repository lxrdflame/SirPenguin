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
    public AudioClip clickSound;
    public AudioClip selectedSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void PlayClickSound()
    {
        if (clickSound != null)
            audioSource.PlayOneShot(clickSound);
    }

    void PlaySelectedSound()
    {
        if (selectedSound != null)
            audioSource.PlayOneShot(selectedSound);
    }

    public void OnClickStart()
    {
        PlayClickSound();
        PlaySelectedSound();

        confirmationPanel.SetActive(true);
        eventSystem.SetSelectedGameObject(tickGameObject);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }

    public void OnClickQuit()
    {
        PlayClickSound();
        Application.Quit();
    }

    public void OnClickControls()
    {
        PlayClickSound();

        controlsPanel.SetActive(true);
        eventSystem.SetSelectedGameObject(closeGameObject);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }

    public void OnClickTick()
    {
        PlaySelectedSound();
        SceneManager.LoadScene("StartScreen");
    }

    public void OnClickX()
    {
        PlaySelectedSound();
        SceneManager.LoadScene("FreeForAll");
    }

    public void OnClickClosePanel()
    {
        PlayClickSound();

        controlsPanel.SetActive(false);
        eventSystem.SetSelectedGameObject(startGameObject);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }
    }

    public void OnClickBack()
    {
        PlayClickSound();

        confirmationPanel.SetActive(false);
        eventSystem.SetSelectedGameObject(startGameObject);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }
    }
}
