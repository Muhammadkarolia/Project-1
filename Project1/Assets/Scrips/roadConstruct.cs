using UnityEngine;

public class roadButtonBehaviour : MonoBehaviour
{
    public void OnButtonClicked()
    {
        GameObject.Find("/placed objects").BroadcastMessage("ConstructRoad");
    }
}
