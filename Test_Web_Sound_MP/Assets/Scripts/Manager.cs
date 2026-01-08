using UnityEngine;
using System.Collections.Generic;
public class Manager : MonoBehaviour
{
    
    public List<EmotionEntry> emotions_json = new List<EmotionEntry>();
    public List<PressEvent> press_events = new List<PressEvent>();

    
    public string session_id;
    public string song_id = "";
    
    public string age = "";
    public string gender = "";

    public string imagery = "";
    public string add_ons = "";
    
    public int VVIQ1_1, VVIQ1_2, VVIQ1_3, VVIQ1_4;
    public int VVIQ2_1, VVIQ2_2, VVIQ2_3, VVIQ2_4;
    public int VVIQ3_1, VVIQ3_2, VVIQ3_3, VVIQ3_4;
    public int VVIQ4_1, VVIQ4_2, VVIQ4_3, VVIQ4_4;

    public string how_listening = "";
    public string where_listening = "";
    
    public int total_E_count;
    public int total_I_count;
    
    public NewMonoBehaviourScript click_listener;
    
    
    void Awake()
    {
        if (string.IsNullOrEmpty(session_id))
            session_id = System.Guid.NewGuid().ToString("N");
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (click_listener != null)
        {
            total_E_count = click_listener.E_count;
            total_I_count = click_listener.I_count;
        }
    }
}
