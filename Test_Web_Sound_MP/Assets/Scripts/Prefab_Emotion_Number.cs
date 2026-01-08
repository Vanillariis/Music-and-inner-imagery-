using TMPro;
using UnityEngine;

public class Prefab_Emotion_Number : MonoBehaviour
{
    [SerializeField] private TMP_Text emotionNumber;

    public void SetNumber(int number)
    {
        emotionNumber.text = number.ToString();
    }
}

