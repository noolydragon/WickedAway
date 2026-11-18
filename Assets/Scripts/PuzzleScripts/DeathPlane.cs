using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    [Header("Spawn Settings")]
    public Transform respawnPoint;
    private Transform playerPoint;
    public GameObject player;


    void Start()
    {
        playerPoint = GameObject.FindGameObjectWithTag("CinemachineTarget").transform;
    }

    void Update()
    {
        if (playerPoint.position.y <= -2f)
        {
            RespawnPlayer(player);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            RespawnPlayer(other.gameObject);
        }
    }

    private void RespawnPlayer(GameObject player)
    {
        if (respawnPoint != null)
        {
            player.transform.position = respawnPoint.position;

            if (player.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            else if (player.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb2d))
            {
                rb2d.linearVelocity = Vector2.zero;
                rb2d.angularVelocity = 0f;
            }
        }
        else
        {
            Debug.LogWarning("Respawn Point is missing on the Death Plane script!", gameObject);
        }
    }
}
