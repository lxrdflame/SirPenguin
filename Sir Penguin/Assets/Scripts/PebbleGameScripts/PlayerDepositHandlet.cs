using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerDepositHandlet : MonoBehaviour
{
    public bool isHoldingDeposit { get; private set; }

    public float depositDistance = 3f;
    public LayerMask cashBoxLayer;

    private PlayerWallet wallet;
    private CashBox currentBox;
    [SerializeField] private RawImage triangleUI;
    private void Start()
    {
        wallet = GetComponent<PlayerWallet>();
    }

    private void Update()
    {
        if (!isHoldingDeposit)
        {
            if (currentBox != null)
                currentBox.ResetDeposit();

            currentBox = null;
            return;
        }

        Ray ray = new Ray(transform.position + Vector3.up, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, depositDistance, cashBoxLayer))
        {
            CashBox box = hit.collider.GetComponent<CashBox>();

            if (box != null)
            {
                currentBox = box;
                box.StartDeposit(wallet);
            }
        }
        else
        {
            if (currentBox != null)
                currentBox.ResetDeposit();

            currentBox = null;
        }
    }

    public void OnDeposit(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isHoldingDeposit = true;
            triangleUI.color = Color.green;
        }
        else if (context.canceled)
        {
            isHoldingDeposit = false;
            triangleUI.color = Color.white;

        }
    }
}
