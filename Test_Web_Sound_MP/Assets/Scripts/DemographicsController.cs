using UnityEngine;
using UnityEngine.UI;

public class DemographicsController : MonoBehaviour
{
    public Manager manager;

    [Header("Assign the ToggleGroup components")]
    public ToggleGroup ageGroup;
    public ToggleGroup genderGroup;

    public void SaveAge()
    {
        manager.age = ToggleGroupReader.GetSelectedLabel(ageGroup);
        Debug.Log("Saved age: " + manager.age);
    }

    public void SaveGender()
    {
        manager.gender = ToggleGroupReader.GetSelectedLabel(genderGroup);
        Debug.Log("Saved gender: " + manager.gender);
    }

    // Optional: if you want one button to save both
    public bool SaveBoth()
    {
        manager.age = ToggleGroupReader.GetSelectedLabel(ageGroup);
        manager.gender = ToggleGroupReader.GetSelectedLabel(genderGroup);

        Debug.Log($"Saved: age={manager.age}, gender={manager.gender}");

        // return true if both selected
        return !string.IsNullOrEmpty(manager.age) && !string.IsNullOrEmpty(manager.gender);
    }
}