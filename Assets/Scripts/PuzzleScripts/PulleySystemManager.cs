using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class PulleySystemManager : MonoBehaviour
{
    [Header("Pulley Setup/Order")]
    [Tooltip("List of pulleys in the order they should be activated.")]
    [SerializeField] private List<FreezeableObject> pulleysInOrder = new List<FreezeableObject>();
    private int currentPulleyIndex = 0;

    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] private float rotationToSolve = 360f;
    private Dictionary<FreezeableObject, float> pulleyRotations = new Dictionary<FreezeableObject, float>();

    [Header("Drawbridge Settings")]
    [SerializeField] private Transform drawbridge;
    [SerializeField] private Vector3 targetRotation = new Vector3(180f, 0f, 0f);
    [SerializeField] private float dropDuration = 2f;

    private bool puzzleSolved = false;

    void Start()
    {
        foreach (var pulley in pulleysInOrder)
        {
            if (pulley != null)
            {
                pulleyRotations[pulley] = 0f;
            }
        }
    }

    void Update()
    {
        if (puzzleSolved) return;

        if (currentPulleyIndex < pulleysInOrder.Count)
        {
            FreezeableObject currentPulley = pulleysInOrder[currentPulleyIndex];

            if (currentPulley != null && currentPulley.isUnfrozen)
            {
                RotatePulley(currentPulley);
            }
        }
    }

    private void RotatePulley(FreezeableObject pulley)
    {
        float step = rotationSpeed * Time.deltaTime;

        pulley.transform.Rotate(Vector3.up, step);
        pulleyRotations[pulley] += Mathf.Abs(step);

        if (pulleyRotations[pulley] >= rotationToSolve)
        {
            CompletePulleyStep();
        }
    }

    private void CompletePulleyStep()
    {
        FreezeableObject solvedPulley = pulleysInOrder[currentPulleyIndex];
        Debug.Log($"Pulley [{solvedPulley.objectColor}] successfully wound/loosened!");

        currentPulleyIndex++;

        if (currentPulleyIndex >= pulleysInOrder.Count)
        {
            DropDrawbridge();
        }
    }

    private void DropDrawbridge()
    {
        puzzleSolved = true;

        if (drawbridge != null)
        {
            Debug.Log("Drawbridge dropping attempt");
            drawbridge.DORotate(targetRotation, dropDuration).SetEase(Ease.OutBounce);
        }
    }
}