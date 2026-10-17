using UnityEngine;
using TMPro;

public class OhmsLawCalculator : MonoBehaviour
{
    public Transform pointA;
    public Transform currentTarget;

    public TextMeshProUGUI ammeterText;
    public TextMeshProUGUI voltmeterText;

    // Define readings for each knob
    [System.Serializable]
    public struct KnobReading
    {
        public string knobName;
        public float current; // in Amps
        public float voltage; // in Volts
    }

    public KnobReading[] knobReadings;

    void Update()
    {
        if (currentTarget != null)
        {
            bool found = false;
            foreach (var reading in knobReadings)
            {
                if (currentTarget.name == reading.knobName)
                {
                    ammeterText.text = reading.current.ToString("F2") + " A";
                    voltmeterText.text = reading.voltage.ToString("F2") + " V";
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                // If the knob isn't found, show zero readings
                ammeterText.text = "0.00 A";
                voltmeterText.text = "0.00 V";
            }
        }
        else
        {
            // No connection → show zero readings
            ammeterText.text = "0.00 A";
            voltmeterText.text = "0.00 V";
        }
    }

    public void AttachToTarget(Transform target)
    {
        currentTarget = target;
    }

    public void DetachFromTarget()
    {
        currentTarget = null;
    }
}
