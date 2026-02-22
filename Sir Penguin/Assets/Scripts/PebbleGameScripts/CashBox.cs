using UnityEngine;

public class CashBox : MonoBehaviour
{
    public string playerTag;
    public float depositTime = 10f;

    private float currentTimer = 0f;
    private PlayerWallet currentPlayer;

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;

        PlayerWallet wallet = other.GetComponent<PlayerWallet>();
        PlayerDepositHandlet input = other.GetComponent<PlayerDepositHandlet>();

        if (wallet == null || input == null) return;

        if (input.isHoldingDeposit)
        {
            if (currentPlayer != wallet)
            {
                currentPlayer = wallet;
                currentTimer = 0f;
            }

            currentTimer += Time.deltaTime;

            Debug.Log("Depositing: " + currentTimer);

            if (currentTimer >= depositTime)
            {
                int deposited = wallet.DepositAllPebbles();
                Debug.Log(playerTag + " deposited: " + deposited);

                currentTimer = 0f;
            }
        }
        else
        {
            ResetDeposit();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerWallet>() == currentPlayer)
        {
            ResetDeposit();
        }
    }

    void ResetDeposit()
    {
        currentTimer = 0f;
        currentPlayer = null;
    }
}
