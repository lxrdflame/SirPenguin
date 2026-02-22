using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    public int currentPebbles = 0;

    public void AddPebbles(int amount)
    {
        currentPebbles += amount;
        Debug.Log(gameObject.name + " collected pebbles: " + currentPebbles);
    }

    public int DepositAllPebbles()
    {
        int amount = currentPebbles;
        currentPebbles = 0;
        return amount;
    }

    public GameObject pebblePrefab;

    public void DropPebbles()
    {
        for (int i = 0; i < currentPebbles; i++)
        {
            Vector3 offset = Random.insideUnitSphere;
            offset.y = 0.5f;

            Instantiate(pebblePrefab, transform.position + offset, Quaternion.identity);
        }

        currentPebbles = 0;

        //When Rea makes heath script dont forget to call: wallet.DropCoins(); thank conman lol.
    }
}
