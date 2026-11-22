using UnityEngine;
using UnityEngine.Events;

public class ObjectController : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator _animator;
    [Header("Audio Settings")]

    public AudioClip objectSound;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void AnimateObject()
    {
        _animator.SetTrigger("AnimateObject");
        AudioManager.instance.PlaySound(objectSound);
    }
}