using UnityEngine;
using UnityEngine.Events;

public class ObjectController : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator _animator;
    [Header("Audio Settings")]

    public AudioClip objectSound;
    public ParticleSystem objectParticleEffect;
    private bool allowAnimation = true;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void AnimateObject()
    {
        _animator.SetTrigger("AnimateObject");
        if (objectParticleEffect != null && allowAnimation)
        {
            objectParticleEffect.Play();
            AudioManager.instance.PlaySound(objectSound);
        }
        allowAnimation = false;
    }
}