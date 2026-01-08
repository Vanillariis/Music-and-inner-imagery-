using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class ToggleGroupReader
{
    // Returns the label text of the currently selected toggle in this group.
    // Works with TextMeshProUGUI labels.
    public static string GetSelectedLabel(ToggleGroup group)
    {
        if (!group) return "";

        var onToggle = group.ActiveToggles().FirstOrDefault();
        if (!onToggle) return "";

        // Your toggles have a child named "Label" (from your screenshot),
        // typically holding a TMP_Text / TextMeshProUGUI component.
        var tmp = onToggle.GetComponentInChildren<TMP_Text>(true);
        if (tmp) return tmp.text.Trim();

        // Fallback if you used legacy Text somewhere
        var txt = onToggle.GetComponentInChildren<UnityEngine.UI.Text>(true);
        if (txt) return txt.text.Trim();

        return onToggle.name;
    }
}

