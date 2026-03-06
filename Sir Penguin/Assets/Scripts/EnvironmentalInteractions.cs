using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnvironmentalInteractions : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private int jumpForce;
    [SerializeField] private PlayerWallet playerWalletScript;
    [SerializeField] private List<Transform> PebblePositions;
    private HpManager hpManagerScript;
    public SeagulScript seagullScript;
    private PlayerInput playerInput;

    //Desposite Hut Settings
    [SerializeField] private Transform DepositeHut, DepositeUI;
    [SerializeField] private int MaxDistance;
    public Transform Camera;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerWalletScript = GetComponent<PlayerWallet>();
        hpManagerScript = GetComponent<HpManager>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        float Distance = Vector3.Distance(transform.position, DepositeHut.position);
        if (Distance <= MaxDistance)
        {
            DepositeUI.gameObject.SetActive(true);
            DepositeUI.LookAt(Camera.position);
        }
        else
        {
            DepositeUI.gameObject.SetActive(false);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pad"))
        {
            OnJumpPad();
        }
        else if (other.CompareTag("Pebble"))
        {
            if (playerInput.playerIndex == 0)
            {
                seagullScript.canAttckPlayer[0] = true;
            }
            else
            {
                seagullScript.canAttckPlayer[1] = true;
            }
            playerWalletScript.AddPebbles(1);
            for (int i = 0; i < PebblePositions.Count; i++)
            {
                if (PebblePositions[i].childCount == 0)
                {
                    other.gameObject.transform.position = PebblePositions[i].position;
                    other.gameObject.transform.SetParent(PebblePositions[i]);
                    other.gameObject.transform.localScale = new Vector3(0.33f, 0.33f, 0.33f);
                    SphereCollider Sc = other.gameObject.GetComponent<SphereCollider>();
                    Destroy(Sc);
                    break;
                }
            }

        }
        else if (other.CompareTag("SnowBall"))
        {
            hpManagerScript.DepleteHP(10);
            Destroy(other.gameObject, 0.05f);
            hpManagerScript.HpRestore();
        }
        else if (other.CompareTag("Seagull"))
        {
            
            if(playerInput.playerIndex == 0)
            {
                seagullScript.canAttckPlayer[0] = false;

            }
            else
            {
                seagullScript.canAttckPlayer[1] = false;
            }
            playerWalletScript.RemovePebbles(1);

            for (int i = PebblePositions.Count - 1; i >= 0; i--)
            {
                if (PebblePositions[i].childCount == 1)
                {
                    GameObject CurrentPebble = PebblePositions[i].GetChild(0).gameObject;
                    Destroy(CurrentPebble);
                    break;
                }
            }
        }
    }
    public void OnJumpPad()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
    }
}
