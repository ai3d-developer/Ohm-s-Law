using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WireEnd : MonoBehaviour
{
    [HideInInspector] public bool isConnected = false;
    [HideInInspector] public Terminal connectedTerminal = null;

    private Collider myCollider;
    private XRGrabInteractable grab;   // if using XR grab
    private float disconnectDistance = 0.1f; // how far you can pull before it disconnects

    void Start()
    {
        myCollider = GetComponent<Collider>();
        grab = GetComponentInParent<XRGrabInteractable>(); // assumes parent wire has XRGrab
    }

    private void OnTriggerEnter(Collider other)
    {
        Terminal t = other.GetComponent<Terminal>();
        if (t == null || isConnected || t.isConnected) return;

        // Snap and parent
        transform.position = t.transform.position;
        transform.rotation = t.transform.rotation;
        transform.SetParent(t.transform, true);

        // Mark connected
        isConnected = true;
        connectedTerminal = t;
        t.isConnected = true;
        t.connectedEnd = this;

        Debug.Log($"{name} connected to {t.terminalID}");
    }

    void Update()
    {
        // If connected, check distance from socket
        if (isConnected && connectedTerminal != null)
        {
            float dist = Vector3.Distance(transform.position, connectedTerminal.transform.position);
            if (dist > disconnectDistance)
            {
                Disconnect();
            }
        }
    }

    public void Disconnect()
    {
        if (connectedTerminal != null)
        {
            connectedTerminal.isConnected = false;
            connectedTerminal.connectedEnd = null;
        }

        isConnected = false;
        connectedTerminal = null;

        // Unparent → free again
        transform.SetParent(null);

        // Re-enable collider so it can reconnect
        if (myCollider != null) myCollider.enabled = true;

        Debug.Log($"{name} disconnected");
    }
}
