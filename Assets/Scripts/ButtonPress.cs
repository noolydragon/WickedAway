using UnityEngine;
using UnityEngine.Events;

public class ButtonPress : MonoBehaviour
{
    [Header("Threshold Settings")]
    public float threshold = 0.8f; // Percentage (0 to 1) of max travel to trigger click
    public float deadZone = 0.2f;   // Buffer zone to avoid jittering

    [Header("Events")]
    public UnityEvent onPressed;
    public UnityEvent onReleased;
    public UnityEvent onHeld;

    private bool isPressed = false;
    private bool isHeld = false;
    private ConfigurableJoint joint;
    private Vector3 startPosition;

    void Start()
    {
        joint = GetComponent<ConfigurableJoint>();
        startPosition = transform.localPosition;
    }

    void Update()
    {
        // Calculate percentage traveled based on the joint's linear limit
        float currentDistance = Vector3.Distance(startPosition, transform.localPosition);
        float maxTravel = joint.linearLimit.limit;
        float pressPercentage = Mathf.Clamp01(currentDistance / maxTravel);

        if (!isPressed && pressPercentage >= threshold)
        {
            Pressed();
        }
        else if (isPressed && pressPercentage <= deadZone)
        {
            Released();
        }
    }

    private void Held()
    {
        isHeld = true;
        onHeld.Invoke();
        Debug.Log("Button Held!");
    }

    private void Pressed()
    {
        isPressed = true;
        onPressed.Invoke();
        Debug.Log("Button Pressed!");
    }

    private void Released()
    {
        isPressed = false;
        onReleased.Invoke();
        Debug.Log("Button Released!");
    }
}
