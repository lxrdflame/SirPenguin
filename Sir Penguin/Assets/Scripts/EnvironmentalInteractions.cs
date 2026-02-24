using UnityEngine;

public class EnvironmentalInteractions : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private int jumpForce;
    [SerializeField] private PlayerWallet playerWalletScript;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        }
    }
    public void OnJumpPad()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
    }
}
