using UnityEngine;

public class Pebble : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter(Collider other)
    {
        PlayerWallet wallet = other.GetComponent<PlayerWallet>();

        if (wallet != null)
        {
            wallet.AddPebbles(value);
            Destroy(gameObject);
        }
    }
}
