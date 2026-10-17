using XCharts;
using UnityEngine;
using XCharts.Runtime;

public class GraphPlotter : MonoBehaviour
{
    public LineChart lineChart;

    void Start()
    {
        lineChart.ClearData();
        lineChart.AddSerie(SerieType.Line, "Voltage-Current");
    }

    public void AddPoint(float voltage, float current)
    {
        lineChart.AddData(0, voltage, current);
    }
}
