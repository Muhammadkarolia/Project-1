using UnityEngine;

public class constructButtonBehaviour : MonoBehaviour
{
    public string buildingName;
    public void OnButtonClicked()
    {
        GameObject.Find("/placed objects/tiles").BroadcastMessage("ConstructBuilding", buildingName);
    }
}
