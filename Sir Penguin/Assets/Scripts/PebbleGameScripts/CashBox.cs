using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CashBox : MonoBehaviour
{
    public int playerIndex;
    public float depositTime = 2f;
    public TextMeshProUGUI scoreText;
    private int totalDeposited = 0;

    private float currentTimer = 0f;
    private PlayerWallet currentPlayer;

    public void StartDeposit(PlayerWallet wallet)
    {
        if (wallet.GetComponent<PlayerInput>().playerIndex != playerIndex)
            return;

        if (currentPlayer != wallet)
        {
            currentPlayer = wallet;
            currentTimer = 0f;
        }

        currentTimer += Time.deltaTime;

        if (currentTimer >= depositTime)
        {
            int deposited = wallet.DepositAllPebbles();
            totalDeposited += deposited;

            if (scoreText != null)
                scoreText.text = totalDeposited.ToString();

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
