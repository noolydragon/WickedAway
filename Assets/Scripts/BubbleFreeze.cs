using UnityEngine;

public class BubbleFreeze : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.TryGetComponent<ObjectPointFollow>
        (out ObjectPointFollow objectPointFollow)
        && other.CompareTag("Frozen"))
        {
            objectPointFollow.tag = "Unfrozen";
            objectPointFollow.Move();
            objectPointFollow.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent<ObjectPointFollow>
        (out ObjectPointFollow objectPointFollow)
        && other.CompareTag("Unfrozen"))
        {
            objectPointFollow.tag = "Frozen";
            objectPointFollow.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
