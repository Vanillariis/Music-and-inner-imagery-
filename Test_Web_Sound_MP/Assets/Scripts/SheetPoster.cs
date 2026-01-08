using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class SheetPoster : MonoBehaviour
{
    [SerializeField] private string googleAppsScriptUrl;

    public IEnumerator PostPayload(QuestionnairePayload payload)
    {
        // Send as form data (avoids CORS preflight)
        WWWForm form = new WWWForm();

        form.AddField("session_id", payload.session_id ?? "");
        form.AddField("song_id", payload.song_id ?? "");
        form.AddField("age", payload.age ?? "");
        form.AddField("gender", payload.gender ?? "");

        form.AddField("VVIQ1_1", payload.VVIQ1_1);
        form.AddField("VVIQ1_2", payload.VVIQ1_2);
        form.AddField("VVIQ1_3", payload.VVIQ1_3);
        form.AddField("VVIQ1_4", payload.VVIQ1_4);

        form.AddField("VVIQ2_1", payload.VVIQ2_1);
        form.AddField("VVIQ2_2", payload.VVIQ2_2);
        form.AddField("VVIQ2_3", payload.VVIQ2_3);
        form.AddField("VVIQ2_4", payload.VVIQ2_4);

        form.AddField("VVIQ3_1", payload.VVIQ3_1);
        form.AddField("VVIQ3_2", payload.VVIQ3_2);
        form.AddField("VVIQ3_3", payload.VVIQ3_3);
        form.AddField("VVIQ3_4", payload.VVIQ3_4);

        form.AddField("VVIQ4_1", payload.VVIQ4_1);
        form.AddField("VVIQ4_2", payload.VVIQ4_2);
        form.AddField("VVIQ4_3", payload.VVIQ4_3);
        form.AddField("VVIQ4_4", payload.VVIQ4_4);

        form.AddField("how_listening", payload.how_listening ?? "");
        form.AddField("where_listening", payload.where_listening ?? "");

        form.AddField("imagery", payload.imagery ?? "");
        form.AddField("add_ons", payload.add_ons ?? "");

        // Send these as JSON strings inside the form
        form.AddField("emotions_json", JsonUtility.ToJson(new EmotionWrapper(payload.emotions_json)));
        form.AddField("press_events", JsonUtility.ToJson(new PressWrapper(payload.press_events)));

        using (UnityWebRequest req = UnityWebRequest.Post(googleAppsScriptUrl, form))
        {
            Debug.Log("Sending WebGL-safe POST (WWWForm)...");
            yield return req.SendWebRequest();

            Debug.Log($"POST finished. result={req.result} http={req.responseCode}");
            Debug.Log("Response text: " + req.downloadHandler.text);

            if (req.result == UnityWebRequest.Result.Success)
                Debug.Log("POST success!");
            else
                Debug.LogError("POST failed: " + req.error);
        }
    }

    [System.Serializable]
    private class EmotionWrapper
    {
        public EmotionEntry[] items;
        public EmotionWrapper(System.Collections.Generic.List<EmotionEntry> list)
            => items = list != null ? list.ToArray() : new EmotionEntry[0];
    }

    [System.Serializable]
    private class PressWrapper
    {
        public PressEvent[] items;
        public PressWrapper(System.Collections.Generic.List<PressEvent> list)
            => items = list != null ? list.ToArray() : new PressEvent[0];
    }
}



