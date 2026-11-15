using UnityEngine;
using UnityEngine.Events;

public class ObjectController : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void AnimateObject()
    {
        _animator.SetTrigger("AnimateObject");
    }
}