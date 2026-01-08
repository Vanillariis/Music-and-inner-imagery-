using System.Collections;
using UnityEngine;

public class StartMusic : MonoBehaviour
{

    public Manager manager;
    public GameObject button;
    public Timer timer;
    public GameObject timer_Object;
    public AudioSource sad_music;
    public AudioSource happy_music;
    public AudioSource audio_source;
    public bool music_as_started = false;
   
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        timer.onTimerEnd.AddListener(OnTimerEnded);
    }

    void OnDisable()
    {
        timer.onTimerEnd.RemoveListener(OnTimerEnded);
    }

    void OnTimerEnded()
    {
        Debug.Log("Timer ended!");
        timer_Object.SetActive(false);
        
        startMusic();

        music_as_started = true;
    }

    void startMusic()
    {
        if (Random.value < 0.5f)
        {
            sad_music.Play();
            audio_source = sad_music;

            manager.song_id = "sad";   // ✅ STORE SONG HERE
        }
        else
        {
            happy_music.Play();
            audio_source = happy_music;

            manager.song_id = "happy"; // ✅ STORE SONG HERE
        }

        Debug.Log("Song selected: " + manager.song_id);

        Invoke("stopMusic", 120f);
    }


    void stopMusic()
    {
        StartCoroutine(StartMusic.FadeOut(audio_source, 2f));
        audio_source.Stop();
        button.SetActive(true);
    }
    
    public static IEnumerator FadeOut(AudioSource audioSource, float fadeDuration)
    {
        if (audioSource == null) yield break;

        float startVolume = audioSource.volume;

        while (audioSource.volume > 0.001f)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        audioSource.volume = 0f;
        audioSource.Stop();
        audioSource.volume = startVolume; // Reset for next play
    }

}
