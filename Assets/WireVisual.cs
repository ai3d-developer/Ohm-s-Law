using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class WireVisual : MonoBehaviour
{
    public WireEnd endA;
    public WireEnd endB;

    private LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.useWorldSpace = true;

        // Always visible (shows cable even before connecting)
        lr.enabled = true;
    }

    void Update()
    {
        Vector3 posA = endA.isConnected && endA.connectedTerminal != null
            ? endA.connectedTerminal.transform.position
            : endA.transform.position;

        Vector3 posB = endB.isConnected && endB.connectedTerminal != null
            ? endB.connectedTerminal.transform.position
            : endB.transform.position;

        lr.SetPosition(0, posA);
        lr.SetPosition(1, posB);
    }
}

