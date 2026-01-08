using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class After_Listening : MonoBehaviour
{
    public Manager manager;
    public TMP_Text e_count_text;

    public RectTransform content;
    public RectTransform buttonInContent;
    public GameObject emotionRatingPrefab;

    int lastCount = -1;

    void Update()
    {
        int count = manager.total_E_count;

        e_count_text.text = count.ToString();

        if (count != lastCount)
        {
            lastCount = count;
            Populate(count);
        }
    }

    void Populate(int count)
    {
        // Clear old spawned items (keep the button)
        for (int i = content.childCount - 1; i >= 0; i--)
        {
            Transform child = content.GetChild(i);
            if (child != buttonInContent)
                Destroy(child.gameObject);
        }

        // Spawn items BEFORE the button
        for (int i = 0; i < count; i++)
        {
            var go = Instantiate(emotionRatingPrefab, content);
            go.transform.SetSiblingIndex(buttonInContent.GetSiblingIndex());

            var item = go.GetComponent<EmotionRatingItem>();
            item.SetNumber(i + 1);
        }

        buttonInContent.SetAsLastSibling();

        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(content);
    }


    public List<EmotionEntry> CollectEmotionEntries()
    {
        var list = new List<EmotionEntry>();

        for (int i = 0; i < content.childCount; i++)
        {
            Transform child = content.GetChild(i);
            if (child == buttonInContent) continue;

            var item = child.GetComponent<EmotionRatingItem>();
            if (!item) continue;

            list.Add(item.GetData());
        }

        return list;
    }

    public bool AllEmotionsComplete()
    {
        Debug.Log(">>> AllEmotionsComplete() VERSION: 2025-12-28 A");

        for (int i = 0; i < content.childCount; i++)
        {
            Transform child = content.GetChild(i);
            if (child == buttonInContent) continue;

            var item = child.GetComponent<EmotionRatingItem>();
            if (!item)
            {
                Debug.LogWarning($"Child {child.name} has no EmotionRatingItem.");
                continue;
            }

            var d = item.GetData();

            if (string.IsNullOrWhiteSpace(d.emotion))
            {
                Debug.LogWarning($"Emotion #{d.index} missing EMOTION selection.");
                return false;
            }

            if (d.intensity == 0)
            {
                Debug.LogWarning($"Emotion #{d.index} missing INTENSITY selection.");
                return false;
            }

            if (d.valence == 0)
            {
                Debug.LogWarning($"Emotion #{d.index} missing VALENCE selection.");
                return false;
            }

            if (d.emotion.Trim().ToLower() == "other" && string.IsNullOrWhiteSpace(d.other_text))
            {
                Debug.LogWarning($"Emotion #{d.index} selected OTHER but text is empty.");
                return false;
            }
        }

        return true;
    }
    
    public void OnNextFromEmotions()
    {
        if (!AllEmotionsComplete())
            return;

        // Save into Manager NOW (so it survives leaving this screen)
        manager.emotions_json = CollectEmotionEntries();

        Debug.Log("Saved emotions into Manager. Going next...");
        // call your navigation here (ButtonActions.NextScreen)
    }


}




