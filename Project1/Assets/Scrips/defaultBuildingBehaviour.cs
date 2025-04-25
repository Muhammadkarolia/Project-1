using UnityEngine;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;

public class defaultBuildingBehaviour : MonoBehaviour
{
    public GameObject managementSystem;
    private managementSystem ms;
    private int taxation = 10;
    public int level = 1;
    public GameObject buildingPanel;
    private buildingPanelBehaviour bpb;
    private TextInfo textInfo;
    private string productionType;
    private int bonus;
    void Awake()
    {
        textInfo = new CultureInfo("en-UK", false).TextInfo;
        bpb = buildingPanel.GetComponent<buildingPanelBehaviour>();
        ms = managementSystem.GetComponent<managementSystem>();
        switch (this.name)
        {
            case "house":
                productionType = "workers";
                taxation = 5;
                break;
            case "office":
                productionType = "money";
                taxation = 100;
                break;
            case "school":
                productionType = "education";
                taxation = -20;
                break;
            case "park":
                productionType = "relaxation";
                taxation = -10;
                break;
            default:
                productionType = "safety";
                taxation = -10;
                break;
        }
    }
        
    public void Display()
    {
        bpb.Activate(this.gameObject);
        bpb.buildingName.text = textInfo.ToTitleCase(this.name);
        bpb.productionType.text = productionType;
        bpb.levelLabel.text = "level: "+level.ToString();
        bpb.nextLevelCostLabel.text = "next level: $" + (level * 100).ToString();
        bpb.taxation.text = "$" + taxation.ToString();
    }
    public void Create()
    {
        switch (this.name)
        {
            case "house":
                ms.AddHouses(1);
                break;
            case "office":
                ms.AddOffices(1);
                break;
            case "school":
                ms.AddSchools(1);
                break;
            case "park":
                ms.AddParks(1);
                break;
            case "fire station":
                ms.AddFireStations(1);
                break;
            case "police station":
                ms.AddPoliceStations(1);
                break;
            case "hospital":
                ms.AddHospitals(1);
                break;
        }
        ms.AddTax(taxation);
    }
    public void Destroy()
    {
        this.gameObject.SetActive(false);
        switch (this.name)
        {
            case "house":
                ms.AddHouses(-1);
                break;
            case "office":
                ms.AddOffices(-1);
                break;
            case "school":
                ms.AddSchools(-1);
                break;
            case "park":
                ms.AddParks(-1);
                break;
            case "fire station":
                ms.AddFireStations(-1);
                break;
            case "police station":
                ms.AddPoliceStations(-1);
                break;
            case "hospital":
                ms.AddHospitals(-1);
                break;
        }
        ms.AddTax(-taxation);
    }
    public void Upgrade()
    {
        if (ms.GetMoney() >= level * 100)
        {
            ms.AddMoney(-100 * level);
            if (taxation > 0)
            {
                ms.AddTax(Mathf.RoundToInt(-taxation * 0.8f) + taxation);
                taxation = Mathf.RoundToInt(taxation * 0.8f);
            }
            else
            {
                ms.AddTax(Mathf.RoundToInt(taxation * 1.2f) - taxation);
                taxation = Mathf.RoundToInt(taxation * 1.2f);
            }
                level += 1;
            bpb.levelLabel.text = "level: " + level.ToString();
            bpb.nextLevelCostLabel.text = "next level: $" + (level * 100).ToString();
            bpb.taxation.text = "$" + taxation.ToString();
        }
    }
}
