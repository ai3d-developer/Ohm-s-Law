using UnityEngine;
using UnityEngine.UI;
using System.Text;

[System.Serializable]
public class KnobData
{
    internal readonly object knob;
    public string knobName;
    public float currentValue;
    public float voltageValue;
}

public class KnobSwitchSystem : MonoBehaviour
{
    public KnobData[] knobs;
    public Text tableText;

    void Update()
    {
        DisplayReadings();
    }

    private void DisplayReadings()
    {
        if (tableText == null)
            return;

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Knob\tCurrent (A)\tVoltage (V)");

        foreach (var knob in knobs)
        {
            StringBuilder stringBuilder = sb.AppendLine(value: $"{knob.knob}\t{knob }\t{knob }");
        }

        tableText.text = sb.ToString();
    }
}
