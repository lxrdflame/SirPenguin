using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDepositHandlet : MonoBehaviour
{
    public bool isHoldingDeposit { get; private set; }

    public void OnDeposit(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isHoldingDeposit = true;
        }
        else if (context.canceled)
        {
            isHoldingDeposit = false;
        }
    }
}
