using UnityEngine;
using TMPro;

public class AddOnsUI : MonoBehaviour
{
    public Manager manager;
    public TMP_InputField addOnsInput;

    public void SaveAddOns()
    {
        manager.add_ons = addOnsInput ? addOnsInput.text : "";
        Debug.Log("Saved add_ons: " + manager.add_ons);
    }
}

