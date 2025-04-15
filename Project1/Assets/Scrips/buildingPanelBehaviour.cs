using UnityEngine;
using TMPro;

public class buildingPanelBehaviour : MonoBehaviour
{
    public GameObject changeProductionMenu;
    public TMP_Text buildingName;
    public TMP_Text timer;
    public TMP_Text productionType;
    public TMP_Text taxation;
    public GameObject changeButton;
    public GameObject collectButton;
    private GameObject linkedBuilding;
    private bool active;

    void Start()
    {
        this.gameObject.SetActive(false);
    }
    public void Activate(GameObject building)
    {
        if (active)
        {
            this.gameObject.SetActive(false);
            active = false;
        }
        else
        {
            this.gameObject.SetActive(true);
            linkedBuilding = building;
            active = true;
            if (linkedBuilding.name == "factory")
            {
                changeButton.SetActive(true);
                collectButton.SetActive(true);
            }
            else
            {
                changeButton.SetActive(false);
                collectButton.SetActive(false);
            }
        }
    }
    public void Activate()
    {
        if (active)
        {
            this.gameObject.SetActive(false);
            active = false;
        }
        else
        {
            Debug.LogError("acivating panel requires building to be passed");
        }
    }
    public void ChangeProduction(string newProductionType)//only for factories
    {
        linkedBuilding.GetComponent<factoryBehaviour>().ChangeProduction(newProductionType);
        changeProductionMenu.SetActive(false);
    }
    public void Collect()
    {
        linkedBuilding.GetComponent<factoryBehaviour>().Collect();
    }
    public void Unselect()
    {
        linkedBuilding.transform.parent.GetComponent<tileBehaviours>().Unselect();
    }
}
