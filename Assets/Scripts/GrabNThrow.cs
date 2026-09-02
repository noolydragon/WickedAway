using UnityEngine;
using UnityEngine.InputSystem;

public class GrabNThrow : MonoBehaviour
{
    public GameObject playerHands;
    GameObject objectToHold;
    public float throwForce = 10.0f;
    

    private bool canGrab = true;
    private bool hasItem = false;

    InputAction grabAction;
    InputAction throwAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grabAction = InputSystem.actions.FindAction("Grab");
        throwAction = InputSystem.actions.FindAction("Throw");
    }

    // Update is called once per frame
    void Update()
    {
        if (canGrab == true)
        {
            if (grabAction.IsPressed())
            {
                objectToHold.GetComponent<Rigidbody>().isKinematic = true;
                objectToHold.transform.position = playerHands.transform.position;
                objectToHold.transform.parent = playerHands.transform;
            }
            hasItem = true;
        }
        if (throwAction.IsPressed() && hasItem == true)
        {
            objectToHold.GetComponent<Rigidbody>().isKinematic = false;
            objectToHold.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
            objectToHold.transform.parent = null;   
        }
        hasItem = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "grabbable")
        {
            canGrab = true;
            objectToHold = other.gameObject;
        }
    }

    void OnTriggerExit()
    {
        canGrab = false;
    }
}
