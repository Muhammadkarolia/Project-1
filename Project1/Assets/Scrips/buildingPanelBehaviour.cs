using UnityEngine;
using TMPro;

public class buildingPanelBehaviour : MonoBehaviour
{
    public GameObject changeProductionMenu;
    public TMP_Text buildingName;
    public TMP_Text timer;
    public TMP_Text productionType;
    public TMP_Text taxation;
    public TMP_Text levelLabel;
    public TMP_Text nextLevelCostLabel;
    public GameObject changeButton;
    public GameObject upgradeButton;
    public GameObject collectButton;
    private GameObject linkedBuilding;
    private bool active;

    void Start()
    {
        changeButton.SetActive(false);
        collectButton.SetActive(false);
        timer.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
    public void Activate(GameObject building)
    {
        if (active)
        {
            Activate();
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
                timer.gameObject.SetActive(true);
            }
            
        }
    }
    public void Activate()
    {
        if (active)
        {
            changeButton.SetActive(false);
            collectButton.SetActive(false);
            timer.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            active = false;

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
    public void Upgrade()
    {
        linkedBuilding.SendMessage("Upgrade");
    }
}
