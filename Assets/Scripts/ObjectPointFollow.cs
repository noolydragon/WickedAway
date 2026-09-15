using System.Collections.Generic;
using UnityEngine;

public class ObjectPointFollow : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int speed = 5;
    public int currentPoint;
    public bool isFrozen = true;
    public bool isTimerRunning = false;
    [SerializeField] private float timeRemaining = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //currentPoint = 0;
        //transform.position = patrolPoints[currentPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTimerRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
        }
        else
        {
            timeRemaining = 0;
            isTimerRunning = false;
        }
    }

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
    }
}
