using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class SeagulScript : MonoBehaviour
{
    [SerializeField]
    private List<Transform> FlyPoints;
    [SerializeField] private int FlySpeed; 
    [SerializeField] private int FlyIndex;


    private void Update()
    {
        transform.LookAt(FlyPoints[FlyIndex]);
        transform.position = Vector3.MoveTowards(transform.position, FlyPoints[FlyIndex].position, FlySpeed * Time.deltaTime);
        
        float distance = Vector3.Distance(transform.position , FlyPoints[FlyIndex].position);
        if (distance <= 0)
        {
            if (FlyIndex == FlyPoints.Count - 1)
            {
                FlyIndex = 0;
            }
            else
            {
                FlyIndex++;
            }
        }
    }

}
