using UnityEngine;
using TMPro;

public class ImageryUI : MonoBehaviour
{
    public Manager manager;
    public TMP_InputField imageryInput;

    public void SaveImagery()
    {
        manager.imagery = imageryInput ? imageryInput.text : "";
        Debug.Log("Saved imagery: " + manager.imagery);
    }
}