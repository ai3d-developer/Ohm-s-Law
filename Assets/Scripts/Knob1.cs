using UnityEngine;

public class Knob1 : MonoBehaviour
{
    public int knobIndex;  // e.g., 4 for knob5
    public ShowGraphOnKnob5 graphManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Switch"))
        {
            graphManager.OnKnobTouched(knobIndex);
        }
    }
}


