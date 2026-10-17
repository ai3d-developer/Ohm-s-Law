using UnityEngine;

public class CurrentController : MonoBehaviour
{
    private float currentTarget;
    private float voltageTarget;

    public void SetCurrentTarget(float value)
    {
        currentTarget = value;
    }

    public void SetVoltageTarget(float value)
    {
        voltageTarget = value;
    }

    public float GetCurrentTarget() { return currentTarget; }
    public float GetVoltageTarget() { return voltageTarget; }
}
