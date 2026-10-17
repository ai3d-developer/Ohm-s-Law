using UnityEngine;

public class WireConnect : MonoBehaviour
{
    public Transform pointA; // The movable endpoint
    public Transform currentTarget; // The object pointA snaps to
    public float snapDistance = 0.3f; // Distance threshold for snapping

    private LineRenderer lineRenderer;
    private bool isSnapped = false;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer missing on this GameObject!");
        }
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        if (pointA == null)
            return;

        // Update lineRenderer positions
        lineRenderer.SetPosition(0, pointA.position);

        if (currentTarget != null)
        {
            lineRenderer.SetPosition(1, currentTarget.position);
        }
        else
        {
            lineRenderer.SetPosition(1, pointA.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnapTarget") && !isSnapped)
        {
            AttachToTarget(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SnapTarget") && isSnapped && other.transform == currentTarget)
        {
            DetachFromTarget();
        }
    }

    private void AttachToTarget(Transform target)
    {
        currentTarget = target;
        isSnapped = true;
        pointA.position = currentTarget.position; // Snap instantly
    }

    private void DetachFromTarget()
    {
        currentTarget = null;
        isSnapped = false;
    }
}
