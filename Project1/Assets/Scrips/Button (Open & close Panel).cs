using UnityEngine;
using UnityEngine.UI;

public class BuidlingButton : MonoBehaviour
{
    public GameObject uiToToggle; 
    private bool _isUIActive = false;
    public Button myButton;

    void Start()
    {
        if (uiToToggle != null)
        {
            uiToToggle.SetActive(false);
        }
        if(myButton != null)
        {
            myButton.onClick.AddListener(ToggleUiElement);
        }
        else
        {
            Debug.LogError("Button not assigned");
        }
    }

    public void ToggleUiElement()
    {
        if (uiToToggle != null)
        {
            _isUIActive = !_isUIActive;
            uiToToggle.SetActive(_isUIActive);
        }
        else
        {
            Debug.LogError("UI to toggle is not assigned!");
        }
    }
}
