using UnityEngine;

public class tutorialBehaviour : MonoBehaviour
{
    public GameObject[] tutorials;
    public GameObject window;
    private int counter;
    public void NextTutorial()
    {
        tutorials[counter].SetActive (false);
        counter++;
        if (counter < tutorials.Length)
        {
            tutorials[counter].SetActive (true);
        }
        else
        {
            window.SetActive(false);
        }
    }
}