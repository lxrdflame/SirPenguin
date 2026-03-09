using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutScript : MonoBehaviour
{
    public GameObject ControlsScreen;
    public GameObject StartConfirmPanel;
    [SerializeField] private MultiplayerEventSystem eventSystem;
    [SerializeField] private GameObject ButtonToSelect;

    private bool player1Ready = false;
    private bool player2Ready = false;
    [SerializeField] private RawImage buttonImage;
    TutScript gameCheck;
    public GameObject OtherChecker;


    private void Start()
    {
        if (ControlsScreen != null)
            ControlsScreen.SetActive(false);

        if (StartConfirmPanel != null)
            StartConfirmPanel.SetActive(false);

        gameCheck = OtherChecker.GetComponent<TutScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("SnowBall")) return;

        if (gameObject.CompareTag("StartTrigger"))
        {
            StartConfirmPanel.SetActive(true);
            eventSystem.SetSelectedGameObject(ButtonToSelect);
            Destroy(other.gameObject);
        }

        if (gameObject.CompareTag("ControlsTrigger"))
        {
            ControlsScreen.SetActive(true);
        }

        if (gameObject.CompareTag("ExitTrigger"))
        {
            ControlsScreen.SetActive(false);
        }

    }


    private void Update()
    {
        if (player1Ready && player2Ready)
        {
            SceneManager.LoadScene("FreeForAll");

        }

        
    }
    // UI BUTTONS
    public void Player1Yes()
    {
        player1Ready = true;
        gameCheck.player1Ready = true;
        buttonImage.color = Color.green;

    }

    public void Player2Yes()
    {
        player2Ready = true;
        gameCheck.player1Ready = true;
        buttonImage.color = Color.green;
    }

    public void Player1No()
    {
        player1Ready = false;
    }

    public void Player2No()
    {
        player2Ready = false;
    }

    private void CheckStartGame()
    {
        
            SceneManager.LoadScene("FreeForAll");
        
    }

}
