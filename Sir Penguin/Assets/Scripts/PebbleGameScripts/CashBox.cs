using UnityEngine;

public class CashBox : MonoBehaviour
{
    public float depositTime = 2f;

    private float currentTimer = 0f;
    private PlayerWallet currentPlayer;

    public void StartDeposit(PlayerWallet wallet)
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
            Debug.Log(wallet.gameObject.name + " deposited: " + deposited);

            currentTimer = 0f;
        }
    }

    public void ResetDeposit()
    {
        currentTimer = 0f;
        currentPlayer = null;
    }
}
