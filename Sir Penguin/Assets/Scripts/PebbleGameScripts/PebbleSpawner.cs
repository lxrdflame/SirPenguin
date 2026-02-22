using UnityEngine;

public class PebbleSpawner : MonoBehaviour
{
    public GameObject pebblePrefab;
    public float respawnTime = 5f;

    private GameObject currentPebble;

    void Start()
    {
        SpawnPebble();
    }

    void Update()
    {
        if (currentPebble == null)
        {
            Invoke(nameof(SpawnPebble), respawnTime);
        }
    }

    void SpawnPebble()
    {
        currentPebble = Instantiate(pebblePrefab, transform.position, Quaternion.identity);
    }
}
