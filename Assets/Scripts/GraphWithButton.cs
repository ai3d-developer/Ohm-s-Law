using UnityEngine;
using XCharts;
using XCharts.Runtime;

public class GraphWithButton : MonoBehaviour
{
    public LineChart lineChart;  // Assign this in the inspector

    void Start()
    {
        // Hide the chart when the scene starts
        if (lineChart != null)
        {
            lineChart.gameObject.SetActive(false);
        }
    }

    // This method will be called when the button is pressed
    public void ShowGraph()
    {
        if (lineChart != null)
        {
            lineChart.gameObject.SetActive(true);
            lineChart.RefreshChart();
        }
    }
}
