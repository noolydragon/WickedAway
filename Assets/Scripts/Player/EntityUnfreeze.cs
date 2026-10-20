using UnityEngine;

public class EntityUnfreeze : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<UnfreezeManager>(out UnfreezeManager manager))
        {
            manager.Unfreeze();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<UnfreezeManager>(out UnfreezeManager manager))
        {
            manager.Freeze();
        }
    }
}
