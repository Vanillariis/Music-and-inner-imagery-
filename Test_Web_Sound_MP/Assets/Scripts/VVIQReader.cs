using System.Linq;
using UnityEngine.UI;

public static class VVIQReader
{
    // Returns 1..N based on which toggle is selected (order in hierarchy)
    public static int GetSelectedNumber(ToggleGroup group)
    {
        if (!group) return 0;

        var toggles = group.GetComponentsInChildren<Toggle>(true);
        var active = group.ActiveToggles().FirstOrDefault();

        if (!active) return 0;

        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i] == active)
                return i + 1; // 1-based index
        }

        return 0;
    }
}

