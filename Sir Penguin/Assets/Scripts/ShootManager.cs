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
    public Transform PlayerCamera;
    private void FixedUpdate()
    {
        if (!isRunning)
        {
            OnShoot();
        }
    }


    public void OnShoot()
    {
        StartCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
        if (isShooting)
        {
            yield return new WaitForSeconds(ShootRate);
            Ray ray = new Ray(PlayerCamera.position, PlayerCamera.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                targetPoint = hit.point;
            }
            GameObject SnowBall = Instantiate(snowBallPrefab, ShootPoint.position, Quaternion.identity);
            SnowBallScript = SnowBall.GetComponent<SnowballController>();
            SnowBallScript.targetPoint = targetPoint;
            StartCoroutine(Shoot());

        }

    }
}
