using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class UnfreezeManager : MonoBehaviour
{
    public enum ObjectType {PhysicsOnly, Follower, Patrol}
    public Rigidbody rb;

    [Header("Object Behavior Type")]
    public ObjectType objectType = ObjectType.PhysicsOnly;

    [Header("Patroling Object Settings")]
    public Transform[] patrolPoints;
    public int speed = 5;
    public int currentPoint;

    [Header("Physics Object Settings")]
    public bool isUnfrozen = false;
    
    [Header("Following Objects Settings")]
    [SerializeField] private Transform target; // Mostly the player
    [SerializeField] private float verticalForce = 1.5f;
    [SerializeField] private float forwardForce = 1f;
    [SerializeField] private float jumpCooldown = 3f; //3 seconds to jump again
    [SerializeField] private bool isGrounded = true;

    void Start()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) target = player.transform;   
        }

        if (isUnfrozen) Unfreeze(); else Freeze();

        StartCoroutine(JumpRoutine());
    }

    void Update()
    {
        if (!isUnfrozen) return;

        if (objectType == ObjectType.Patrol)
        {
            Patrol();
        }
    }

    private IEnumerator JumpRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(jumpCooldown);

            if (isUnfrozen && objectType == ObjectType.Follower && target != null && isGrounded)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, target.position);
                JumpTowardsPlayer();
            }
        }
    }

    public void JumpTowardsPlayer()
    {
        isGrounded = false;

        Vector3 targetDirection = target.position - transform.position;
        targetDirection.y = 0f;
        targetDirection.Normalize();

        Vector3 jumpVelocity = (targetDirection * forwardForce) + (Vector3.up * verticalForce);

        rb.AddForce(jumpVelocity, ForceMode.Impulse);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
    public void Unfreeze()
    {
        isUnfrozen = true;

        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }
    public void Freeze()
    {
        isUnfrozen = false;

        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
