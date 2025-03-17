using UnityEngine;

public class removeButtonBehaviour : MonoBehaviour
{
    public void OnButtonClicked()
    {
        transform.root.BroadcastMessage("DeconstructBuilding");
    }
}
