using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;  // only if you want Export CSV

public class OhmsLawManager : MonoBehaviour
{
    [Header("Inputs")]
    public KnobController voltageKnob;
    public TMP_Dropdown resistanceDropdown;

    [Header("Meter Displays")]
    public TMP_Text voltageText;   // above Voltmeter
    public TMP_Text currentText;   // above Ammeter

    [Header("Table UI")]
    public TMP_Text tableText;
    public ScrollRect tableScrollRect;
    public Button recordButton;
    public Button resetButton;
    public Button exportButton;   // optional

    // table & calc state
    private float resistance = 100f;
    private int rowCount = 0;
    private const string Header = "Row |   V (V) |  R (Ω) |    I (A)\n"
                                + "----+---------+--------+-----------\n";

    void Start()
    {
        if (resistanceDropdown)
            resistanceDropdown.onValueChanged.AddListener(_ => UpdateResistance());

        if (recordButton) recordButton.onClick.AddListener(RecordRow);
        if (resetButton) resetButton.onClick.AddListener(ResetTable);
        if (exportButton) exportButton.onClick.AddListener(ExportCSV);

        UpdateResistance();
        InitTableHeader();
    }

    void Update()
    {
        float V = voltageKnob ? voltageKnob.Voltage : 0f;
        float I = (resistance > 0f) ? V / resistance : 0f;

        if (voltageText) voltageText.text = $"V = {V:F2} V";
        if (currentText) currentText.text = $"I = {I:F4} A";
    }

    void UpdateResistance()
    {
        float r = resistance;
        if (resistanceDropdown)
        {
            // expects numeric option texts like "10", "47", "100"
            float.TryParse(resistanceDropdown.options[resistanceDropdown.value].text, out r);
        }
        resistance = Mathf.Max(0.0001f, r);
    }

    // ---- Table helpers ----
    void InitTableHeader()
    {
        if (tableText) tableText.text = Header;
        rowCount = 0;
        ScrollToBottom();
    }

    void RecordRow()
    {
        if (!tableText) return;

        float V = voltageKnob ? voltageKnob.Voltage : 0f;
        float I = (resistance > 0f) ? V / resistance : 0f;

        rowCount++;
        // Aligned columns (works best with monospaced font asset)
        string line = string.Format("{0,3} | {1,7:F2} | {2,6:F0} | {3,9:F4}\n",
                                    rowCount, V, resistance, I);

        tableText.text += line;
        // force layout and auto-scroll to newest
        Canvas.ForceUpdateCanvases();
        ScrollToBottom();
    }

    void ResetTable()
    {
        InitTableHeader();
    }

    void ScrollToBottom()
    {
        if (tableScrollRect)
        {
            // 0 = bottom, 1 = top
            tableScrollRect.verticalNormalizedPosition = 0f;
        }
    }

    // ---- Optional: Export CSV to persistent path ----
    void ExportCSV()
    {
        if (!tableText) return;

        string path = Path.Combine(Application.persistentDataPath, "ohms_observations.csv");

        // Rebuild CSV from tableText (drop ASCII header line)
        string[] lines = tableText.text.Split('\n');
        using (var sw = new StreamWriter(path))
        {
            sw.WriteLine("Row,V,R,I");
            for (int i = 0; i < lines.Length; i++)
            {
                // skip first 2 header lines and empties
                if (i < 2 || string.IsNullOrWhiteSpace(lines[i])) continue;

                // line format: "  1 |    3.50 |    100 |    0.0350"
                string[] parts = lines[i].Split('|');
                if (parts.Length != 4) continue;

                string row = parts[0].Trim();
                string v_str = parts[1].Trim().Split(' ')[0]; // remove "(V)" if any
                string r_str = parts[2].Trim().Split(' ')[0];
                string i_str = parts[3].Trim().Split(' ')[0];

                sw.WriteLine($"{row},{v_str},{r_str},{i_str}");
            }
        }
        Debug.Log("CSV saved: " + path);
    }
}
