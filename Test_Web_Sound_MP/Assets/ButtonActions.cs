using UnityEngine;

public class ButtonActions : MonoBehaviour
{
    public Canvas nextScreen;
    private Canvas currentScreen;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentScreen = GetComponentInParent<Canvas>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScreen()
    {
        currentScreen.gameObject.SetActive(false);
        nextScreen.gameObject.SetActive(true);
        
        currentScreen = nextScreen;
    }

    public void SelectButton()
    {
        
    }

}
