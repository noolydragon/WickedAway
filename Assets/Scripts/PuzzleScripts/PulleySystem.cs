using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class PulleySystem : MonoBehaviour
{
    [Header("Pulley Settings")]
    public List<GameObject> pulleys = new List<GameObject>();
    public int numOfPulleys;
    public float rotationSpeed = 50f;
    public bool isPulled = false;
    [Header("Drawbridge Reference")]
    [SerializeField] private Transform drawbridge;
    [SerializeField] private float targetAngle = 180f;
    [SerializeField] private float dropDuration = 2f;

    private FreezeableObject freezeable;
    private float currentRotationAmount = 0f;
    [SerializeField] private float rotationToSolve = 360f;

    void Start()
    {
        numOfPulleys = pulleys.Count;
    }
    
    void Awake()
    {
        freezeable = GetComponent<FreezeableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPulled) return;

        if (freezeable != null && freezeable.isUnfrozen)
        {
            RotatePulley();
        }
    }

    private void RotatePulley()
    {
        float step = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, step);
        currentRotationAmount += Mathf.Abs(step);

        if (currentRotationAmount >= rotationToSolve)
        {
            PullPulley();
        }
    }

    private void PullPulley()
    {
        isPulled = true;
        if (drawbridge == null)
        {
            drawbridge.DORotate(new Vector3(targetAngle, drawbridge.eulerAngles.y, drawbridge.eulerAngles.z), dropDuration).SetEase(Ease.OutBounce);
        }
    }
}
