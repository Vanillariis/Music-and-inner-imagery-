using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSubmit : MonoBehaviour
{
    public Manager manager;
    public SheetPoster poster;

    public void OnSubmit()
    {
        Debug.Log("OnSubmit clicked - START");

        if (manager == null)
        {
            Debug.LogError("manager is NULL (not assigned in Inspector).");
            return;
        }

        if (poster == null)
        {
            Debug.LogError("poster is NULL (not assigned in Inspector).");
            return;
        }

        // Optional: if you REQUIRE emotions, validate here
        // if (manager.emotions_json == null || manager.emotions_json.Count == 0)
        // {
        //     Debug.LogWarning("Blocked submit: no emotions saved.");
        //     return;
        // }

        Debug.Log("Building payload...");
        var payload = new QuestionnairePayload
        {
            session_id = manager.session_id,
            age = manager.age,
            gender = manager.gender,

            // VVIQ (include these if you want them in the payload!)
            VVIQ1_1 = manager.VVIQ1_1, VVIQ1_2 = manager.VVIQ1_2, VVIQ1_3 = manager.VVIQ1_3, VVIQ1_4 = manager.VVIQ1_4,
            VVIQ2_1 = manager.VVIQ2_1, VVIQ2_2 = manager.VVIQ2_2, VVIQ2_3 = manager.VVIQ2_3, VVIQ2_4 = manager.VVIQ2_4,
            VVIQ3_1 = manager.VVIQ3_1, VVIQ3_2 = manager.VVIQ3_2, VVIQ3_3 = manager.VVIQ3_3, VVIQ3_4 = manager.VVIQ3_4,
            VVIQ4_1 = manager.VVIQ4_1, VVIQ4_2 = manager.VVIQ4_2, VVIQ4_3 = manager.VVIQ4_3, VVIQ4_4 = manager.VVIQ4_4,

            how_listening = manager.how_listening,
            where_listening = manager.where_listening,
            
            song_id = manager.song_id,
            
            imagery = manager.imagery,
            add_ons = manager.add_ons,

            emotions_json = manager.emotions_json,
            
            press_events = manager.press_events

        };

        Debug.Log("Starting POST coroutine...");
        StartCoroutine(poster.PostPayload(payload));
    }
}