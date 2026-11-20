using UnityEngine;

public class EntityBehavior : MonoBehaviour
{
    private Transform entityTarget;
    public AudioClip entitySound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        entityTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Flame"))
        {
            AudioSource.PlayClipAtPoint(entitySound, transform.position);
            transform.LookAt(entityTarget);
        }
    }
}
