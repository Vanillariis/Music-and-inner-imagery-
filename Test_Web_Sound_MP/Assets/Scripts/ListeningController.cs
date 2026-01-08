using UnityEngine;
using UnityEngine.UI;

public class ListeningController : MonoBehaviour
{
    public Manager manager;

    [Header("Assign ToggleGroup components")]
    public ToggleGroup howGroup;   // Airpods/Headphones/Speakers
    public ToggleGroup whereGroup; // Busy/Calm/Home...

    public void SaveListening()
    {
        manager.how_listening = ToggleGroupReader.GetSelectedLabel(howGroup);
        manager.where_listening = ToggleGroupReader.GetSelectedLabel(whereGroup);

        if (string.IsNullOrEmpty(manager.how_listening) || string.IsNullOrEmpty(manager.where_listening))
        {
            Debug.LogWarning("Please select both how you are listening and where you are listening.");
            return;
        }

        Debug.Log($"Saved listening: how={manager.how_listening}, where={manager.where_listening}");

        // If you have navigation, call it here (or call it after this method in the button OnClick)
        // e.g. manager.GoToNextScreen(); or your ButtonActions script
    }
}