using UnityEngine;

public class KnobController : MonoBehaviour
{
    public float minAngle = -90f;
    public float maxAngle = 90f;
    public float minVoltage = 0f;
    public float maxVoltage = 10f;

    private float currentAngle = 0f;
    public float Voltage { get; private set; }

    void OnMouseDrag()
    {
        float rot = Input.GetAxis("Mouse X") * 5f;
        currentAngle = Mathf.Clamp(currentAngle + rot, minAngle, maxAngle);
        transform.localRotation = Quaternion.Euler(0, currentAngle, 0);

        float t = Mathf.InverseLerp(minAngle, maxAngle, currentAngle);
        Voltage = Mathf.Lerp(minVoltage, maxVoltage, t);
    }
}
