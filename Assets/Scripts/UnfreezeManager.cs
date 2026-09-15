using System.Collections.Generic;
using UnityEngine;

public class UnfreezeManager : MonoBehaviour
{
    public enum ObjectType {PhysicsOnly, Follower, Patrol}

    [Header("Object Behavior Type")]
    public ObjectType objectType = ObjectType.PhysicsOnly;

    [Header("Patroling Object Settings")]
    public Transform[] patrolPoints;
    public int speed = 5;
    public int currentPoint;

    [Header("Physics Object Settings")]
    public bool isUnfrozen = false;
    public Rigidbody rb;
    
    [Header("Following Objects Settings")]
    public Transform target; // Mostly the player

    void Start()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        if(isUnfrozen && objectType == ObjectType.Follower)
        {
            Follow();
        }
    }

    public void Follow()
    {
        if (target == null) return;
        
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.LookAt(target.position);
    }
    public void Unfreeze()
    {
        isUnfrozen = true;

        if(objectType == ObjectType.PhysicsOnly)
        {
            if(rb != null)
            {
                rb.isKinematic = false;
                rb.useGravity = true;
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, -5f, rb.linearVelocity.z);
            }
        }
        else if (objectType == ObjectType.Follower)
        {
            if(rb != null)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
            }
        }
    }
    public void Freeze()
    {
        isUnfrozen = false;

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
            rb.useGravity = false;
        }
    }

    public void Patrol()
    {
        if(patrolPoints == null || patrolPoints.Length == 0) return;

        transform.position = Vector3.MoveTowards(transform.position , patrolPoints[currentPoint].position , speed*Time.deltaTime);
        transform.LookAt(patrolPoints[currentPoint].position);

        if(Vector3.Distance(transform.position, patrolPoints[currentPoint].position) < 0.1f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }
}
