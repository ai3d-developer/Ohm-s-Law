using UnityEngine;
using UnityEngine.UI;

public class MeterDisplay : MonoBehaviour
{
    public CurrentController currentController;

    // Optional: UI Text
    public Text currentText;
    public Text voltageText;

    // Optional: needle rotation
    public RectTransform currentNeedle;
    public RectTransform voltageNeedle;
    public float maxNeedleAngle = 90f;
    public float maxCurrent = 3f;
    public float maxVoltage = 6f;

    void Update()
    {
        // Update UI Text
        if (currentText != null)
            currentText.text = currentController.GetCurrentTarget().ToString("F2") + " A";
        if (voltageText != null)
            voltageText.text = currentController.GetVoltageTarget().ToString("F2") + " V";

        // Update Needle
        if (currentNeedle != null)
        {
            float angle = (currentController.GetCurrentTarget() / maxCurrent) * maxNeedleAngle;
            currentNeedle.localEulerAngles = new Vector3(0, 0, -angle);
        }

        if (voltageNeedle != null)
        {
            float angle = (currentController.GetVoltageTarget() / maxVoltage) * maxNeedleAngle;
            voltageNeedle.localEulerAngles = new Vector3(0, 0, -angle);
        }
    }
}
