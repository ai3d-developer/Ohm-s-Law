using UnityEngine;

public class WireManager : MonoBehaviour
{
    public Terminal socketA;
    public Terminal socketB;

    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        line.enabled = false; // Hidden until connected
    }

    void Update()
    {
        if (socketA.isConnected && socketB.isConnected)
        {
            line.enabled = true;
            line.SetPosition(0, socketA.transform.position);
            line.SetPosition(1, socketB.transform.position);
        }
        else
        {
            line.enabled = false;
        }
    }
}
