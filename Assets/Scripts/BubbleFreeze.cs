using UnityEngine;

public class BubbleFreeze : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.TryGetComponent<ObjectPointFollow>(out ObjectPointFollow objectPointFollow) && other.CompareTag("Frozen"))
        {
            objectPointFollow.isTimerRunning = true;
            objectPointFollow.Move();
        }
    }
}
