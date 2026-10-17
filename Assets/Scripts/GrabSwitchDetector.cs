using UnityEngine;

public class GrabSwitchDetector : MonoBehaviour
{
    public TableDisplay tableDisplay;

    // You can define the voltages and currents here or from another manager
    public float[] voltages = { 0.75f, 1.5f, 2.25f, 3.0f };
    public float[] currents = { 1.5f, 3.0f, 4.5f, 6.0f };

    private void OnTriggerEnter(Collider other)
    {
        Knob knob = other.GetComponent<Knob>();
        if (knob != null)
        {
            int index = knob.index;
            float voltage = index >= 0 && index < voltages.Length ? voltages[index] : 0f;
            float current = index >= 0 && index < currents.Length ? currents[index] : 0f;

            tableDisplay.ShowReading(index, voltage, current);
        }
    }
}
