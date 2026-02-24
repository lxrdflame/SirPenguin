using UnityEngine;

public class SnowballController : MonoBehaviour
{
    public Vector3 targetPoint;
    [SerializeField]
    private int moveSpeed;
    [SerializeField] private GameObject SparkPrefab;
    private bool atPoint;
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);
        if (transform.position == targetPoint )
        {
            Destroy(gameObject, 3);
            if (!atPoint )
            {
                atPoint = true;
                GameObject spark = Instantiate(SparkPrefab, transform.position, Quaternion.identity);
                Destroy(spark, 2);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            Destroy(gameObject, 3);
            GameObject spark = Instantiate(SparkPrefab, transform.position, Quaternion.identity);
            Destroy(spark, 2);
        }
    }
}
