using UnityEngine;
using UnityEngine.EventSystems;
public class rayCast : MonoBehaviour
{
    private Transform hilight;
    private Transform selection;
    private RaycastHit raycastHit;
    private Transform previousHover;
    private Transform previousSelect;
    private bool firstHover;
    private bool firstSelect;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            hilight = raycastHit.transform;
            if (hilight != previousHover)
            {
                if (firstHover)//note that this variable is inverted from what would be expected
                {
                    if (previousHover.gameObject.CompareTag("forward ray interaction"))
                    {
                        previousHover.parent.gameObject.SendMessage("Unhover");
                    }
                    else
                    {
                        previousHover.gameObject.SendMessage("Unhover");
                    }
                }
                else
                {
                    firstHover = true;
                }
                if (hilight.gameObject.CompareTag("forward ray interaction"))
                {
                    hilight.parent.gameObject.SendMessage("Hover");
                }
                else
                {
                    hilight.gameObject.SendMessage("Hover");
                }
                    previousHover = hilight;

            }

        }
        if (Input.GetKey(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject())
        {

            if (Physics.Raycast(ray, out raycastHit))
            {
                selection = raycastHit.transform;
                if (selection != previousSelect)
                {
                    if (firstSelect && !Input.GetKey(KeyCode.LeftShift))
                    {
                        GameObject.Find("/placed objects").BroadcastMessage("Unselect");
                    }
                    else
                    {
                        firstSelect = true;
                    }
                    if (selection.gameObject.CompareTag("forward ray interaction"))
                    {
                        selection.parent.gameObject.SendMessage("Select");
                    }
                    else
                    {
                        selection.gameObject.SendMessage("Select");
                    }
                        previousSelect = selection;
                    
                }
            }
        }
    }
}
