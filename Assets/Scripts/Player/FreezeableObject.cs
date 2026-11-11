using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using DG.Tweening;
public enum ObjectColor
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Purple,
        Pink,
        White
    }
public class FreezeableObject : MonoBehaviour
{
    public Rigidbody rb;

    [Header("Save Settings")]
    public string objectID;
    [Header("Color Settings")]
    public ObjectColor objectColor;
    [Header("State Settings")]
    public bool isUnfrozen = false;

    private Coroutine freezeCoroutine;

    void Start()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    public void Unfreeze()
    {
        string playerColor = FlameWheelController.color;
        Debug.Log($"Attempting unfreeze. Player Color: [{playerColor}] | Object Color: [{objectColor.ToString().ToLower()}]");
        if (playerColor != objectColor.ToString().ToLower())
        {
            return;
        }
        isUnfrozen = true;
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    public IEnumerator FreezeAfterDelay(int sec)
    {
        yield return new WaitForSeconds(sec);
        Freeze();
    }
    public void Freeze()
    {
        isUnfrozen = false;

        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    public ObjectSaveData CaptureState()
    {
        return new ObjectSaveData
        {
            objectID = this.objectID,
            isUnfrozen = this.isUnfrozen,
            position = new SerializableVector3(transform.position)
        };
    }

    public void LoadState(ObjectSaveData data)
    {
        this.objectID = data.objectID;
        this.isUnfrozen = data.isUnfrozen;
        transform.position = data.position.ToVector3();

        if (isUnfrozen) Unfreeze(); else Freeze();
    }
}
