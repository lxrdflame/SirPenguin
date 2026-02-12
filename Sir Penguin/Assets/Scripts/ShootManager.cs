using System.Collections;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    [SerializeField]
    private float ShootRate;
    public bool isShooting;
    public GameObject snowBallPrefab;
    [SerializeField]
    public Vector3 targetPoint;
    [SerializeField]
    private Transform ShootPoint;
    private SnowballController SnowBallScript;
    public bool isRunning;

    private void FixedUpdate()
    {
        if (!isRunning)
        {
            OnShoot();
        }
    }


    void OnShoot()
    {
        StartCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
        if (isShooting)
        {
            yield return new WaitForSeconds(ShootRate);
            GameObject SnowBall = Instantiate(snowBallPrefab, ShootPoint.position, Quaternion.identity);
            SnowBallScript = SnowBall.GetComponent<SnowballController>();
            SnowBallScript.targetPoint = targetPoint;
        }

    }
}
