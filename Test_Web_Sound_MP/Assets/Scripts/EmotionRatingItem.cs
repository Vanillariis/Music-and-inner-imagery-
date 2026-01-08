using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmotionRatingItem : MonoBehaviour
{
    [Header("Display")]
    [SerializeField] private TMP_Text emotionNumberText; // the "emotion number" label (optional)

    [Header("Groups")]
    [SerializeField] private ToggleGroup emotionGroup;   // Anger/Longing/.../Other
    [SerializeField] private ToggleGroup intensityGroup; // 5 toggles
    [SerializeField] private ToggleGroup valenceGroup;   // 5 toggles

    [Header("Other input (enabled only if Other selected)")]
    [SerializeField] private Toggle otherToggle;         // your "Toggle_other"
    [SerializeField] private TMP_InputField otherInput;  // OtherEmotionInput

    private int number = 1;

    void Awake()
    {
        // Make sure other input starts hidden unless "Other" is on
        UpdateOtherInputVisibility();

        // If otherToggle exists, listen for changes
        if (otherToggle != null)
            otherToggle.onValueChanged.AddListener(_ => UpdateOtherInputVisibility());
    }

    public void SetNumber(int n)
    {
        number = n;
        if (emotionNumberText) emotionNumberText.text = n.ToString();
    }

    public EmotionEntry GetData()
    {
        string emotionLabel = GetSelectedLabel(emotionGroup);
        int intensity = GetSelectedIndex(intensityGroup); // 1..5
        int valence = GetSelectedIndex(valenceGroup);     // 1..5

        string otherText = "";
        if (IsOtherSelected(emotionLabel) && otherInput != null)
            otherText = otherInput.text ?? "";

        return new EmotionEntry
        {
            index = number,
            emotion = emotionLabel,
            intensity = intensity,
            valence = valence,
            other_text = otherText
        };
    }

    public bool IsComplete()
    {
        var d = GetData();
        
        if (emotionGroup == null || intensityGroup == null || valenceGroup == null)
        {
            Debug.LogError($"EmotionRatingItem missing references on {gameObject.name}. Check prefab Inspector assignments.");
        }

        if (string.IsNullOrWhiteSpace(d.emotion)) return false;
        if (d.intensity == 0) return false;
        if (d.valence == 0) return false;

        if (IsOtherSelected(d.emotion) && string.IsNullOrWhiteSpace(d.other_text))
            return false;

        return true;
    }

    private void UpdateOtherInputVisibility()
    {
        bool show = (otherToggle != null && otherToggle.isOn);

        if (otherInput != null)
        {
            otherInput.gameObject.SetActive(show);
            if (!show) otherInput.text = ""; // optional: clear when hidden
        }
    }

    private bool IsOtherSelected(string emotionLabel)
    {
        return emotionLabel.Trim().ToLower() == "other";
    }

    private string GetSelectedLabel(ToggleGroup group)
    {
        if (!group) return "";

        var onToggle = group.ActiveToggles().FirstOrDefault();
        if (!onToggle) return "";

        // Your toggles have a child "Label" with TMP text (like earlier screens)
        var tmp = onToggle.GetComponentInChildren<TMP_Text>(true);
        if (tmp) return tmp.text.Trim();

        return onToggle.name;
    }

    private int GetSelectedIndex(ToggleGroup group)
    {
        if (!group) return 0;

        var toggles = group.GetComponentsInChildren<Toggle>(true);
        var active = group.ActiveToggles().FirstOrDefault();
        if (!active) return 0;

        for (int i = 0; i < toggles.Length; i++)
            if (toggles[i] == active)
                return i + 1;

        return 0;
    }
}


