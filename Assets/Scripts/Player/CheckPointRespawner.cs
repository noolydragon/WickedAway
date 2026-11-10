using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointRespawner : MonoBehaviour
{
    public Vector3 candleCheckPoint;

    void Start() //Start is called once before update when the script is run
    {
        
    }

    void Awake()
    {
        candleCheckPoint = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("Return to beginning of game");
            SceneManager.LoadScene("PuzzlesScene");
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
}
