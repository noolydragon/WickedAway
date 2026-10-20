using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointRespawner : MonoBehaviour
{
    [Header("Respawn Settings")]
    public Vector3 candleCheckPoint;

    void Start()
    {
        candleCheckPoint = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reset Please");
            ResetToCheckpoint();
        }
    }

    private void ResetToCheckpoint()
    {
        transform.position = candleCheckPoint;

        if (TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.linearVelocity = Vector3.zero; 
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void HardReset()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && CompareTag("CheckPoint"))
        {
            Debug.Log("Checkpoint enabled");
            candleCheckPoint = other.transform.position;
        }
    }
}
