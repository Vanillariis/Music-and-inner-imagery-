using UnityEngine;
using UnityEngine.UI;

public class VVIQController : MonoBehaviour
{
    public Manager manager;

    [Header("Assign the 4 groups for the current scenario screen")]
    public ToggleGroup q1;
    public ToggleGroup q2;
    public ToggleGroup q3;
    public ToggleGroup q4;

    [Header("Which scenario is this? 1..4")]
    [Range(1,4)]
    public int scenarioNumber = 1;

    public void SaveScenario()
    {
        int v1 = VVIQReader.GetSelectedNumber(q1);
        int v2 = VVIQReader.GetSelectedNumber(q2);
        int v3 = VVIQReader.GetSelectedNumber(q3);
        int v4 = VVIQReader.GetSelectedNumber(q4);

        if (v1 == 0 || v2 == 0 || v3 == 0 || v4 == 0)
        {
            Debug.LogWarning("Please answer all 4 VVIQ items before continuing.");
            return;
        }

        switch (scenarioNumber)
        {
            case 1:
                manager.VVIQ1_1 = v1;
                manager.VVIQ1_2 = v2;
                manager.VVIQ1_3 = v3;
                manager.VVIQ1_4 = v4;
                break;

            case 2:
                manager.VVIQ2_1 = v1;
                manager.VVIQ2_2 = v2;
                manager.VVIQ2_3 = v3;
                manager.VVIQ2_4 = v4;
                break;

            case 3:
                manager.VVIQ3_1 = v1;
                manager.VVIQ3_2 = v2;
                manager.VVIQ3_3 = v3;
                manager.VVIQ3_4 = v4;
                break;

            case 4:
                manager.VVIQ4_1 = v1;
                manager.VVIQ4_2 = v2;
                manager.VVIQ4_3 = v3;
                manager.VVIQ4_4 = v4;
                break;
        }

        Debug.Log($"Saved VVIQ scenario {scenarioNumber}: {v1},{v2},{v3},{v4}");
    }
}