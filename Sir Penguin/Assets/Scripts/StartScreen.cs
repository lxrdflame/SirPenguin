using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public GameObject ControlsScreen;

    public void Start()
    {
        ControlsScreen.SetActive(false);
    }
    public void StartBtn()
    {
        SceneManager.LoadScene("FreeForAll");
    }

    public void ControlBtn()
    {
        ControlsScreen.SetActive(true);
    }

    public void QuitBtn()
    {
        Application.Quit();
    }
}
