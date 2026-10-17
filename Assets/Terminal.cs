using UnityEngine;

public class Terminal : MonoBehaviour
{
    public string terminalID = "A";
    public bool isConnected = false;
    public WireEnd connectedEnd = null;

    private void OnDrawGizmos()
    {
        Gizmos.color = isConnected ? Color.green : Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.03f);
    }
}
