using UnityEngine;
using UnityEngine.Events;

public class ButtonPress : MonoBehaviour
{
    [Header("Button Parts")]
    [SerializeField] private Transform buttonTop;

    [Header("Button Events")]
    public UnityEvent OnButtonPressed;
    public UnityEvent OnButtonHeld;
    public UnityEvent OnButtonReleased;

    private Animator _animator;
    private int _pressTriggerHash;
    private int _heldTriggerHash;
    private int _releaseTriggerHash;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _pressTriggerHash = Animator.StringToHash("Press");
        _heldTriggerHash = Animator.StringToHash("Held");
        _releaseTriggerHash = Animator.StringToHash("Released");
    }

    public void PressButton()
    {
        _animator.SetTrigger(_pressTriggerHash);
        OnButtonPressed.Invoke();
    }

    public void HoldButton()
    {
        _animator.SetTrigger(_heldTriggerHash);
        OnButtonHeld.Invoke();
    }

    public void ReleaseButton()
    {
        _animator.ResetTrigger(_releaseTriggerHash);
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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Frozen"))
        {
            HoldButton();
            Debug.Log("Button Held");
            _animator.SetBool("IsHeld", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Frozen"))
        {
            ReleaseButton();
            Debug.Log("Button Released");
            _animator.SetBool("IsHeld", false);
        }
    }
}