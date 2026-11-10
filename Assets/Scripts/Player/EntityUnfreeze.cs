using UnityEngine;

public class EntityUnfreeze : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<FreezeableObject>(out FreezeableObject freezeable))
        {
            freezeable.Unfreeze();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<FreezeableObject>(out FreezeableObject freezeable))
        {
            StartCoroutine(freezeable.FreezeAfterDelay(3));
        }
    }
}
