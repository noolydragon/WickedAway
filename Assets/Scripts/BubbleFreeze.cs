using UnityEngine;

public class BubbleFreeze : MonoBehaviour
{
    public ObjectPointFollow objectPointFollow;
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
        if(other.CompareTag("Frozen"))
        {
            objectPointFollow.isFrozen = false;
            objectPointFollow.Move();
        }
    }
}
