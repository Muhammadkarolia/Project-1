using UnityEngine;

public class constructButtonBehaviour : MonoBehaviour
{
    public string buildingName;
    public void OnButtonClicked()
    {
        transform.root.BroadcastMessage("ConstructBuilding", buildingName);
    }
}
