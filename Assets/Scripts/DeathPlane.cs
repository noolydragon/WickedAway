using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    [Header("Spawn Settings")]
    [Tooltip("Drag the Transform of your spawn point or starting platform here.")]
    public Transform respawnPoint;

    [Header("Target Settings")]
    [Tooltip("The tag assigned to your player GameObject.")]
    public string playerTag = "Player";
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the zone has the Player tag
        if (other.CompareTag(playerTag))
        {
            RespawnPlayer(other.gameObject);
        }
    }

    private void RespawnPlayer(GameObject player)
    {
        if (respawnPoint != null)
        {
            // Reset position to the spawn point
            player.transform.position = respawnPoint.position;

            // Optional: Reset the physics velocity so the player doesn't keep falling momentum
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
