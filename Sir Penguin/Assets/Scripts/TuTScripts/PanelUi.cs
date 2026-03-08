using UnityEngine;
using UnityEngine.InputSystem;

public class PanelUi : MonoBehaviour
{
    [SerializeField] private GameObject panelToClose;

    public void OnCloseUI(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (panelToClose != null && panelToClose.activeSelf)
        {
            panelToClose.SetActive(false);
        }
    }
}
