using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class EnvironmentalInteractions : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private int jumpForce;
    [SerializeField] private PlayerWallet playerWalletScript;
    [SerializeField] private List<Transform> PebblePositions;
    private HpManager hpManagerScript;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerWalletScript = GetComponent<PlayerWallet>();
        hpManagerScript = GetComponent<HpManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pad"))
        {
            OnJumpPad();
        }
        else if (other.CompareTag("Pebble"))
        {
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
            Destroy(other.gameObject,0.05f);
            hpManagerScript.HpRestore();
        }
    }
    public void OnJumpPad()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
    }
}
