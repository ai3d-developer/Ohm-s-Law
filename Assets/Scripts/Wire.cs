using UnityEngine;

public class Wire : MonoBehaviour
{
    public Transform pointA; // The movable end
    private Transform currentTarget;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer != null)
        {
            lineRenderer.positionCount = 2;
        }
    }

    void Update()
    {
        if (lineRenderer != null)
        {
            lineRenderer.SetPosition(0, pointA.position);
            if (currentTarget != null)
                lineRenderer.SetPosition(1, currentTarget.position);
            else
                lineRenderer.SetPosition(1, pointA.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnapTarget"))
        {
            AttachToTarget(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SnapTarget"))
        {
            DetachFromTarget(other.transform);
        }
    }

    private void AttachToTarget(Transform target)
    {
        currentTarget = target;
        pointA.position = currentTarget.position; // Snap to knob

        Debug.Log("Attached to " + target.name);

        // Find and update the OhmsLawCalculator
        OhmsLawCalculator calculator = FindObjectOfType<OhmsLawCalculator>();
        if (calculator != null)
        {
            calculator.AttachToTarget(target);
        }
    }

    private void DetachFromTarget(Transform target)
    {
        if (currentTarget == target)
        {
            currentTarget = null;
            Debug.Log("Detached from " + target.name);

            OhmsLawCalculator calculator = FindObjectOfType<OhmsLawCalculator>();
            if (calculator != null)
            {
                calculator.DetachFromTarget();
            }
        }
    }
}
