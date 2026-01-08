using UnityEngine;

public class ButtonActions : MonoBehaviour
{
    public Canvas nextScreen; 

    private Canvas currentScreen;

    [SerializeField] private Canvas listeningScreen;
    [SerializeField] private Canvas emotionRatings;
    [SerializeField] private Canvas mentalImagery;
    [SerializeField] private Canvas thankYou;

    private Manager manager;

    void Awake()
    {
        manager = FindFirstObjectByType<Manager>(); 
        
    }

    void Start()
    {
        currentScreen = GetComponentInParent<Canvas>(true); // include inactive parents too
    }

    public void NextScreen()
    {
        currentScreen.gameObject.SetActive(false);

        if (listeningScreen != null)
        {
            if (currentScreen == listeningScreen)
            {
                if (manager.total_E_count == 0 && manager.total_I_count > 0)
                    nextScreen = mentalImagery;
            
                else if (manager.total_E_count == 0 && manager.total_I_count == 0)
                    nextScreen = thankYou;
            }
            else if (currentScreen == emotionRatings)
            {
                if (manager.total_I_count == 0)
                {
                    nextScreen = thankYou;
                }
            }   
        }

        nextScreen.gameObject.SetActive(true);
        currentScreen = nextScreen;
    }
}

