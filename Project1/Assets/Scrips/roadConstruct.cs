using UnityEngine;

public class roadButtonBehaviour : MonoBehaviour
{
    public void OnButtonClicked()
    {
        GameObject.Find("/placed objects/roads").BroadcastMessage("ConstructRoad");
    }
}
