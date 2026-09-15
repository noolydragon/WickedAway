using System.Collections.Generic;
using UnityEngine;

public class ObjectPointFollow : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int speed = 5;
    public int currentPoint;

    public void Move()
    {
        if(transform.position == patrolPoints[currentPoint].position)
        {
            currentPoint++;
        }
        if(currentPoint >= patrolPoints.Length)
        {
            currentPoint = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position , patrolPoints[currentPoint].position , speed*Time.deltaTime);
        transform.LookAt(patrolPoints[currentPoint].position);
    }
}
