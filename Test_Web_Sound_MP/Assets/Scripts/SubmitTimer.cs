using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;


public class SubmitTimer : MonoBehaviour
{

    public Timer submit_timer;
    public GameObject submit_button;
    public GameObject submit_timer_Object;
    public GameObject this_canvas;
    public GameObject final_canvas;
    
    
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
        submit_timer.onTimerEnd.AddListener(OnTimerEnded);
    }

    void OnDisable()
    {
        submit_timer.onTimerEnd.RemoveListener(OnTimerEnded);
    }
    
    public void OnSubmitClicked()
    {
        // 1) Disable submit button
        if (submit_button != null)
            submit_button.gameObject.SetActive(false);

        

        // 3) Show + start timer
        if (submit_timer_Object != null)
            submit_timer_Object.SetActive(true);

        if (submit_timer != null)
            submit_timer.StartTimer(); // <-- if your Timer uses a different method name, see note below
        else
            Debug.LogError("Timer reference missing.");
    }

    public void OnTimerEnded()
    {
        Debug.Log("Timer ended!");
        
        this_canvas.SetActive(false);
        final_canvas.SetActive(true);
        
    }
}
