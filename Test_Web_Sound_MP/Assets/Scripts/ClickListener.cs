using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public StartMusic startMusic;
    public Manager manager;

    public int E_count;
    public int I_count;

    void Start()
    {
        E_count = 0;
        I_count = 0;
    }

    void Update()
    {
        if (startMusic == null || !startMusic.music_as_started)
            return;

        var kb = Keyboard.current;
        if (kb == null) return;

        float musicTime = startMusic.audio_source.time;

        if (kb.eKey.wasPressedThisFrame)
        {
            E_count++;

            manager.press_events.Add(new PressEvent
            {
                key = "E",
                time = musicTime,
                index = E_count
            });

            Debug.Log($"E pressed at {musicTime:F2}s (count: {E_count})");
        }

        if (kb.iKey.wasPressedThisFrame)
        {
            I_count++;

            manager.press_events.Add(new PressEvent
            {
                key = "I",
                time = musicTime,
                index = I_count
            });

            Debug.Log($"I pressed at {musicTime:F2}s (count: {I_count})");
        }
    }
}


