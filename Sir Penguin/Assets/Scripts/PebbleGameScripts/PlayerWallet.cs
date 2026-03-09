using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWallet : MonoBehaviour
{
    public int currentPebbles = 0;
    [SerializeField] private SeagulScript seagullScript;
    private PlayerInput playerInput;
    public List<GameObject> visualPebbles = new List<GameObject>();
    [SerializeField] private EnvironmentalInteractions enteractionsScript;
    public AudioClip ChachingSound;
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        enteractionsScript = GetComponent<EnvironmentalInteractions>();
    }

    private void Update()
    {
        if (currentPebbles > 0)
        {
            if (playerInput.playerIndex == 0)
            {
                seagullScript.playerHasPebbles[playerInput.playerIndex] = true;
            }
            else
            {
                seagullScript.playerHasPebbles[playerInput.playerIndex] = true;
            }
        }
        else
        {
            if (playerInput.playerIndex == 0)
            {
                seagullScript.playerHasPebbles[playerInput.playerIndex] = false;
            }
            else
            {
                seagullScript.playerHasPebbles[playerInput.playerIndex] = false;
            }
        }
    }
    public void AddPebbles(int amount)
    {
        currentPebbles += amount;
        Debug.Log(gameObject.name + " collected pebbles: " + currentPebbles);
    }

    public void RemovePebbles(int amount)
    {
        currentPebbles -= amount;
        Debug.Log(gameObject.name + " collected pebbles: " + currentPebbles);
    }

    public int DepositAllPebbles()
    {
        int amount = currentPebbles;
        currentPebbles = 0;
        enteractionsScript.RemoveAllPebbles();
        AudioSource Chaching = GetComponent<AudioSource>();
        Chaching.clip = ChachingSound;
        Chaching.Play();

        return amount;

        
        //Destroy Pebbles
    }



    public void DropPebbles()
    {
        for (int i = 0; i < currentPebbles; i++)
        {
            Vector3 offset = Random.insideUnitSphere;
            offset.y = 0.5f;

            //Instantiate(pebblePrefab, transform.position + offset, Quaternion.identity);
        }

        currentPebbles = 0;

        enteractionsScript.RemoveAllPebbles();
    }


}
