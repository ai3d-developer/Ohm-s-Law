using UnityEngine;
using XCharts;
using XCharts.Runtime;

public class ShowGraphOnKnob5 : MonoBehaviour
{
    public LineChart lineChart;  // Assign your chart here

    void Start()
    {
        // Hide the graph when the scene starts
        lineChart.gameObject.SetActive(false);
    }

    // This method is called when a knob is touched
    public void OnKnobTouched(int knobIndex)
    {
        // Check if the touched knob is knob5 (index 4 if using 0-based indexing)
        if (knobIndex == 4)
        {
            ShowGraph();
        }
    }

    private void ShowGraph()
    {
        // Show the graph
        lineChart.gameObject.SetActive(true);

        // Refresh it just to be safe
        lineChart.RefreshChart();
    }
}
