using UnityEngine;
using UnityEngine.Events;

public class ButtonPress : MonoBehaviour
{
    [Header("Button Parts")]
    [SerializeField] private Transform _buttonTop;

    [Header("Animator")]
    [SerializeField] private Animator _animator;

    [Header("Button Events")]
    public UnityEvent OnButtonPressed;
    public UnityEvent OnButtonReleased;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PressButton()
    {
        _animator.SetBool("isHeld", true);
        OnButtonPressed.Invoke();
    }

    public void ReleaseButton()
    {
        _animator.SetBool("isHeld", false);
        OnButtonReleased.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Frozen"))
        {
            PressButton();
            Debug.Log("Button Pressed");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Frozen"))
        {
            ReleaseButton();
            Debug.Log("Button Released");
        }
    }
}