using UnityEngine;

public class SnowballController : MonoBehaviour
{
    public Vector3 targetPoint;
    [SerializeField]
    private int moveSpeed;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);
        if (transform.position == targetPoint )
        {
            Destroy(gameObject, 3);
        }
    }
}
