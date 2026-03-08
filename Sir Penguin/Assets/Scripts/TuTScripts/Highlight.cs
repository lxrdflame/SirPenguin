using UnityEngine;
using UnityEngine.InputSystem;

public class Highlight : MonoBehaviour
{
    [Header("Player Settings")]
    public int playerIndex;

    [Header("References")]
    public GameObject silhouetteObject;

    private PlayerWallet targetWallet;

    void Start()
    {
        FindCorrectPlayer();
        silhouetteObject.SetActive(false);
    }

    void FindCorrectPlayer()
    {
        PlayerWallet[] players = FindObjectsOfType<PlayerWallet>();

        foreach (PlayerWallet wallet in players)
        {
            PlayerInput input = wallet.GetComponent<PlayerInput>();

            if (input.playerIndex == playerIndex)
            {
                targetWallet = wallet;
                break;
            }
        }
    }

    void Update()
    {
        if (targetWallet == null) return;

        if (targetWallet.currentPebbles > 0)
            silhouetteObject.SetActive(true);
        else
            silhouetteObject.SetActive(false);
    }
}
