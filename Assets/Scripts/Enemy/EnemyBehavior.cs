using UnityEngine;
using System.Collections;
using DG.Tweening;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private Transform enemyTarget;
    [SerializeField] private float jumpCooldown = 3f;
    public bool isGrounded = false;

    private FreezeableObject freezeable;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        freezeable = GetComponent<FreezeableObject>();
        rb = GetComponent<Rigidbody>();

        enemyTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (freezeable == null || !freezeable.isUnfrozen) return;
    }

    private IEnumerator JumpRoutine()
    {
        while (true)
        {
            if (isGrounded)
            {
                JumpTowardsTarget();
            }
            yield return new WaitForSeconds(jumpCooldown);
        }
    }

    private void JumpTowardsTarget()
    {
        isGrounded = false;
        transform.DOKill();
        Sequence jumpSequence = DOTween.Sequence();
        jumpSequence.Append(transform.DOMoveY(2f, 0.5f));
        jumpSequence.Join(transform.DORotate(new Vector3(360f, 0f, 0f), 0.5f));
        jumpSequence.Join(transform.DOLookAt(enemyTarget.position, 0.5f));
        jumpSequence.Append(transform.DOMoveX(enemyTarget.position.x, 1f));
        jumpSequence.Join(transform.DOMoveZ(enemyTarget.position.z, 1f));
        jumpSequence.Append(transform.DOMoveY(enemyTarget.position.y, 0.2f));
        jumpSequence.OnComplete(() => isGrounded = true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        int groundLayer = LayerMask.NameToLayer("Ground");
        if (collision.gameObject.layer == groundLayer && (collision.contacts.Length > 0 && collision.contacts[0].normal.y > 0.5f))
        {
            isGrounded = true;
        }
    }
}
