using UnityEngine;
using DG.Tweening;

public class CubeTween : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //transform.DOMove(new Vector3(0.0f, 1.0f, 0.0f), 1.0f);
        //transform.DOScale()
        //transform.DOMoveY(1.0f, 1.0f)..OnComplete(DestroySelf);

        TweenHelper.RockDown(transform, 5.0f);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
