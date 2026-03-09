using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TextUi : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    public GameObject UITextContainer;
    [SerializeField] private List<string> GuideText;
    private int CollisionCount;
    private PlayerInput playerControls;
    private bool BothPlayersReady;


    void Start()
    {
        uiText.text = "";
        playerControls = GetComponent<PlayerInput>();
        UITextContainer.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ControlsTrigger"))
        {
            if (CollisionCount == 0)
            {
                CollisionCount++;
                OnFirstGuideText();
                Destroy(other.gameObject);

            }
            else if (CollisionCount == 1)
            {
                OnSecondGuideText();
                Destroy(other.gameObject);

            }
        }


    }

    public void CloseTextUi()
    {
        UITextContainer.SetActive(false);
        playerControls.actions.FindActionMap("Player").Enable();

    }

    void OnFirstGuideText()
    {
        uiText.text = GuideText[0];
        playerControls.actions.FindActionMap("Player").Disable();
        UITextContainer.SetActive(true);

    }

    void OnSecondGuideText()
    {
        uiText.text = GuideText[1];
        playerControls.actions.FindActionMap("Player").Disable();
        UITextContainer.SetActive(true);
    }

    public void StartGame()
    {

    }
}
