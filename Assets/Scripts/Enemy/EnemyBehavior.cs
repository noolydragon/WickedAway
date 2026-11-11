using UnityEngine;
using System.Collections;
using DG.Tweening;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private Transform enemyTarget;
    [SerializeField] private float jumpCooldown = 3f;
    public bool isGrounded = true;

    private FreezeableObject freezeable;
    private Rigidbody rb;
    public AudioClip enemyLandSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        freezeable = GetComponent<FreezeableObject>();
        rb = GetComponent<Rigidbody>();

        enemyTarget = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(JumpRoutine());
    }

    private IEnumerator JumpRoutine()
    {
        while (true)
        {
            if (isGrounded && freezeable != null && freezeable.isUnfrozen)
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

        Vector3 startPos = transform.position;
        Vector3 targetPos = enemyTarget.position;
        
        float groundOffset = 0.5f; 
        Vector3 adjustedTargetPos = new Vector3(targetPos.x, targetPos.y + groundOffset, targetPos.z);
        Vector3 hoverPos = new Vector3(targetPos.x, targetPos.y + 5f, targetPos.z);

        Sequence slamSequence = DOTween.Sequence();

        // 1. Rise up into the air
        slamSequence.Append(transform.DOMoveY(startPos.y + 3f, 0.4f).SetEase(Ease.OutQuad));

        // 2. Spin in a circle (360 degrees around the Y-axis)
        slamSequence.Append(transform.DORotate(new Vector3(0f, 360f, 0f), 0.5f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear));

        // 3. Find and look at the player while moving to hover directly above them
        Vector3 directionToPlayer = (targetPos - transform.position);
        directionToPlayer.y = 0f; // Lock looking direction flat to the plane
        if (directionToPlayer != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            slamSequence.Append(transform.DORotateQuaternion(targetRotation, 0.2f));
        }
        
        slamSequence.Join(transform.DOMove(hoverPos, 0.4f).SetEase(Ease.OutQuad));

        // 4. Brief telegraph pause at the apex before diving
        slamSequence.AppendInterval(0.2f);

        // 5. Slam down rapidly onto the adjusted target position (stopping above ground level)
        slamSequence.Append(transform.DOMove(adjustedTargetPos, 0.15f).SetEase(Ease.InExpo));

        // 6. Impact squash and recovery effect
        slamSequence.Append(transform.DOScaleY(0.6f, 0.05f));
        slamSequence.Append(transform.DOScaleY(1.0f, 0.1f));

        // Reset ground flag on completion
        slamSequence.OnComplete(() => isGrounded = true);
        AudioManager.instance.PlaySound(enemyLandSound);
    }

    private void OnCollisionEnter(Collision collision)
    {
        int groundLayer = LayerMask.NameToLayer("Ground");
        if (collision.gameObject.layer == groundLayer && collision.contactCount > 0 && collision.GetContact(0).normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}
