using UnityEngine;
using UnityEngine.InputSystem;

public class TextUi : MonoBehaviour
{
    public GameObject uiText;

    private bool waitingForInput = false;

    void Start()
    {
        if (uiText != null)
            uiText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerInput>() != null)
        {
            Time.timeScale = 0f; 
            waitingForInput = true;

            if (uiText != null)
                uiText.SetActive(true);
        }
    }

    void Update()
    {
        if (!waitingForInput) return;

        if (Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame)
        {
            Time.timeScale = 1f; 

            if (uiText != null)
                uiText.SetActive(false);

            Destroy(gameObject); 
        }
    }
}
