using UnityEngine;
using UnityEngine.Events;

public class ButtonPress : MonoBehaviour
{
    [Header("Button Parts")]
    [SerializeField] private Transform buttonTop;
    
    [Header("Button Events")]
    public UnityEvent OnButtonPressed;

    private Animator _animator;
    private int _pressTriggerHash;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _pressTriggerHash = Animator.StringToHash("Press");
    }

    public void PressButton()
    {
        _animator.SetTrigger(_pressTriggerHash);
        OnButtonPressed.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PressButton();
        }
    }
}