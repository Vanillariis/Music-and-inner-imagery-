using System;
using System.Collections.Generic;

[Serializable]
public class EmotionEntry
{
    public int index;          // emotion # (1..N)
    public string emotion;     // "Anger", "Longing", "Other", etc.
    public int intensity;      // 1..5
    public int valence;        // 1..5
    public string other_text;  // only filled if emotion == "Other"
}

[Serializable]
public class QuestionnairePayload
{
    public string session_id;
    public string song_id;
    
    public string age;
    public string gender;

    // VVIQ (16 items)
    public int VVIQ1_1, VVIQ1_2, VVIQ1_3, VVIQ1_4;
    public int VVIQ2_1, VVIQ2_2, VVIQ2_3, VVIQ2_4;
    public int VVIQ3_1, VVIQ3_2, VVIQ3_3, VVIQ3_4;
    public int VVIQ4_1, VVIQ4_2, VVIQ4_3, VVIQ4_4;

    public string how_listening;
    public string where_listening;

    // Store as a JSON string OR as a list (script handles either)
    public List<EmotionEntry> emotions_json;
    public List<PressEvent> press_events;

    
    public string imagery;  // free text description
    public string add_ons;  // free text final optional box
}

