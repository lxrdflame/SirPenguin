using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PebbleManager : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public GameObject pebblePrefab;
    public float respawnTime = 5f;

    void Start()
    {
        StartCoroutine(PebbleSpawnerTimer());
    }

    IEnumerator PebbleSpawnerTimer()
    {
        yield return new WaitForSeconds(respawnTime);
        SpawnPebble();
        StartCoroutine(PebbleSpawnerTimer());
    }

    void SpawnPebble()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (spawnPoints[i].childCount == 0)
            {
                GameObject Pebble = Instantiate(pebblePrefab, spawnPoints[i].position, Quaternion.identity);
                Pebble.transform.SetParent(spawnPoints[i].transform);
            }
        }

    }
}
