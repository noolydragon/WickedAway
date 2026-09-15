using System.Threading;
using UnityEngine;

public class BubbleUnfreeze : MonoBehaviour
{
    [Header("Timer Settings")]
    public float timeToFreeze = 5f;
    public bool timerRunning = false;
    void Update()
    {
        if (timerRunning)
        {
            if (timeToFreeze > 0)
            {
                // Subtract the time passed since the last frame
                timeToFreeze -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeToFreeze = 0;
                timerRunning = false;
            }
        }
    }
    // void OnTriggerStay(Collider other)
    // {
    //     if(other.gameObject.TryGetComponent<UnfreezeManager>
    //     (out UnfreezeManager UnfreezeManager)
    //     && other.CompareTag("Frozen"))
    //     {
    //         UnfreezeManager.tag = "Unfrozen";
    //         UnfreezeManager.Follow();
    //         UnfreezeManager.GetComponent<Rigidbody>().isKinematic = false;
    //     }
    // }
    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<UnfreezeManager>
        (out UnfreezeManager unfreezeManager)
        && other.CompareTag("Frozen"))
        {
            other.tag = "Unfrozen";
            unfreezeManager.Unfreeze();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<UnfreezeManager>
        (out UnfreezeManager unfreezeManager)
        && other.CompareTag("Unfrozen"))
        {
            other.tag = "Frozen";
            unfreezeManager.Freeze();
        }
    }
}
