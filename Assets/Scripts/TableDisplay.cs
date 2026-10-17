using UnityEngine;

public class TableDisplay : MonoBehaviour
{
    public GameObject[] voltageRows;
    public GameObject[] currentRows;

    private void Start()
    {
        HideAllRows(); // Start with everything hidden
    }

    public void ShowReading(int index, float voltage, float current)
    {
        if (index >= 0 && index < voltageRows.Length)
        {
            voltageRows[index].SetActive(true);
            currentRows[index].SetActive(true);

            // Set the actual values (assuming TextMeshPro is used)
            var voltageText = voltageRows[index].GetComponent<TMPro.TextMeshProUGUI>();
            var currentText = currentRows[index].GetComponent<TMPro.TextMeshProUGUI>();

            if (voltageText != null)
                voltageText.text = voltage.ToString("F2") + " V";
            if (currentText != null)
                currentText.text = current.ToString("F2") + " A";
        }
    }

    private void HideAllRows()
    {
        foreach (var row in voltageRows)
            row.SetActive(false);

        foreach (var row in currentRows)
            row.SetActive(false);
    }
}
