using UnityEngine;
using UnityEngine.UI;
using XCharts;
using XCharts.Runtime;

[System.Serializable]
public class Reading
{
    public float voltage;
    public float current;
}

public class GraphWithTable : MonoBehaviour
{
    public LineChart lineChart;          // Assign your XChart LineChart
    public GameObject tablePanel;        // Assign your UI panel
    public GameObject tableTextPrefab;   // Assign a UI Text prefab
    public Reading[] readings;           // Voltage/current readings

    private int currentIndex = 0;

    void Start()
    {
        // Clear any existing data
        lineChart.ClearData();

        // Make sure the series exists before adding data
        if (lineChart.series.Count == 0)
        {
            lineChart.AddSerie("Current vs Voltage", SerieType.Line);
        }

        // Clear any previous table rows
        foreach (Transform child in tablePanel.transform)
            Destroy(child.gameObject);
    }

    // Call this when a knob is touched
    public void OnKnobTouched(int knobIndex)
    {
        if (currentIndex >= readings.Length) return;

        Reading r = readings[currentIndex];

        // Add point to the chart series (series index 0)
        lineChart.AddData(0, r.voltage, r.current);

        // Force the chart to refresh
        lineChart.RefreshChart();

        // Add row to the table
        GameObject row = Instantiate(tableTextPrefab, tablePanel.transform);
        row.GetComponent<Text>().text = $"Voltage: {r.voltage} V, Current: {r.current} A";

        currentIndex++;
    }
}

