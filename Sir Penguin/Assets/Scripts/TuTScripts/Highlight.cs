using UnityEngine;
using UnityEngine.InputSystem;

public class Highlight : MonoBehaviour
{
    [Header("Player Settings")]
    public int playerIndex; 

    [Header("References")]
    public Renderer cashboxRenderer;

    [Header("Glow")]
    public Color glowColor = Color.yellow;
    public float glowIntensity = 3f;

    private Material mat;
    private Color originalEmission;

    private PlayerWallet targetWallet;

    void Start()
    {
        mat = cashboxRenderer.material;

        if (mat.HasProperty("_EmissionColor"))
        {
            originalEmission = mat.GetColor("_EmissionColor");
        }

        FindCorrectPlayer();
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
        {
            EnableGlow();
        }
        else
        {
            DisableGlow();
        }
    }

    void EnableGlow()
    {
        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", glowColor * glowIntensity);
    }

    void DisableGlow()
    {
        mat.SetColor("_EmissionColor", originalEmission);
    }
}
