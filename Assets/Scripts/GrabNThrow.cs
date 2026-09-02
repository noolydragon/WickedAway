using UnityEngine;
using UnityEngine.InputSystem;

public class GrabNThrow : MonoBehaviour
{
    public GameObject playerHands;
    public GameObject objectToHold;
    public float throwForce = 10.0f;
    

    private bool canGrab = true;
    private bool hasItem = false;

    InputAction grabAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHands != null)
        {
            
        }
    }
}
