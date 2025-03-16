using UnityEngine;

public class buildingBehaviours : MonoBehaviour
{
    int stopGivingMeErrors;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stopGivingMeErrors = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopGivingMeErrors > 0)
        {
            stopGivingMeErrors = 0;
        }     
    }
}
