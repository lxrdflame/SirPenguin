using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;

public class TutScript : MonoBehaviour
{
    public GameObject ControlsScreen;
    [SerializeField] private MultiplayerEventSystem eventSystem;
    [SerializeField] private GameObject ButtonToSelect;


    private void Start()
    {
        if (ControlsScreen != null)
        {
            ControlsScreen.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("SnowBall")) return;

        if (gameObject.CompareTag("StartTrigger"))
        {
            SceneManager.LoadScene("FreeForAll");
        }

        if (gameObject.CompareTag("ControlsTrigger"))
        {
            ControlsScreen.SetActive(true);
        }

        if (gameObject.CompareTag("ExitTrigger"))
        {
            ControlsScreen.SetActive(false);
        }

        if (gameObject.CompareTag("QuitTrigger"))
        {
            Application.Quit();
        }
    }
}
