using TMPro;
using UnityEngine;

public class SetImageryCount : MonoBehaviour
{
    
public Manager manager;
public TMP_Text i_count_text;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        set_emotion_number();
    }

    void set_emotion_number()
    {
        i_count_text.text  = manager.total_I_count.ToString();
    }
}
