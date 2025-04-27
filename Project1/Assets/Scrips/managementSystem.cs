using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.Examples;

public class managementSystem : MonoBehaviour
{
    private int wood = 2000;
    private int brick = 10000;
    private int metal = 1500;
    private int glass = 1000;
    private int money = 8000;
    private int happiness;
    public TMP_Text woodValue;
    public TMP_Text brickValue;
    public TMP_Text metalValue;
    public TMP_Text glassValue;
    public TMP_Text moneyValue;
    public TMP_Text happinessValue;
    public TMP_Text incomeLabel;
    public TMP_Text workersLabel;
    public TMP_Text totalWorkersLabel;
    public GameObject popup;
    public GameObject staticPopup;
    public GameObject startingFactoryTile;
    public GameObject startingHouseTile1;
    public GameObject startingHouseTile2;
    private GameObject popupInstance;
    private TMP_Text accessablePopup;
    private int income = 0;
    private float timer = 5;
    private float happinessBuff = 0.3f;
    private int parks = 0;
    private int factories = 0;
    private int houses = 0;
    private int schools = 0;
    private int hospitals = 0;
    private int policeStations = 0;
    private int fireStations = 0;
    private int offices = 0;
    private int roads = 0;
    private int freeWorkers = 0;
    private int totalWorkers = 0; 
    void Start()
    {
        woodValue.text = wood.ToString();
        glassValue.text = glass.ToString();
        metalValue.text = metal.ToString();
        brickValue.text = brick.ToString();
        moneyValue.text = money.ToString();
        happinessValue.text = happiness.ToString() + "%";
        startingHouseTile1.GetComponent<tileBehaviours>().Select();
        startingHouseTile1.GetComponent<tileBehaviours>().woodAvailable = 0;
        startingHouseTile1.GetComponent<tileBehaviours>().ConstructBuilding("house");
        startingHouseTile2.GetComponent<tileBehaviours>().Select();
        startingHouseTile2.GetComponent<tileBehaviours>().woodAvailable = 0;
        startingHouseTile2.GetComponent<tileBehaviours>().ConstructBuilding("house");
        startingFactoryTile.GetComponent<tileBehaviours>().Select();
        startingFactoryTile.GetComponent<tileBehaviours>().woodAvailable = 0;
        startingFactoryTile.GetComponent<tileBehaviours>().ConstructBuilding("factory");
    }
    public void AddWood(int value)
    {
        wood += value;
        woodValue.text = wood.ToString();
    }
    public void AddGlass(int value)
    {
        glass += value;
        glassValue.text = glass.ToString();
    }
    public void AddMetal(int value)
    {
        metal += value;
        metalValue.text = metal.ToString();
    }
    public void AddBrick(int value)
    {
        brick += value;
        brickValue.text = brick.ToString();
    }
    public void AddMoney(int value)
    {
        money += value;
        moneyValue.text = money.ToString();
    }
    public void AddHappiness(int value)
    {
        happiness += value;
        happinessValue.text = happiness.ToString() + "%";
    }
    public int GetMoney()
    {
        return money;
    }
    public int GetHappiness()
    {
        return happiness;
    }
    public int GetWood()
    {
        return wood;
    }
    public int GetGlass()
    {
        return glass;
    }
    public int GetMetal()
    {
        return metal;
    }
    public int GetBrick()
    {
        return brick;
    }

    public int GetWorkers()
    {
        if (freeWorkers > 0)
        {
            return freeWorkers;
        }
        else
        {
            return 0;
        }
    }
    public void AddParks(int value)
    {
        parks += value;
    }
    public void AddFactories(int value)
    {
        factories += value;
    }
    public void AddHouses(int value)
    {
        houses += value;
        freeWorkers += value * 5;
        totalWorkers += value * 5;
        workersLabel.text = freeWorkers.ToString();
        totalWorkersLabel.text = totalWorkers.ToString();
    }
    public void AddSchools(int value)
    {
        schools += value;
    }
    public void AddOffices(int value)
    {
        offices += value;
    }
    public void AddPoliceStations(int value)
    {
        policeStations += value;
    }
    public void AddFireStations(int value)
    {
        fireStations += value;
    }
    public void AddHospitals(int value)
    {
        hospitals += value;
    }
    public void AddRoads(int value)
    {
        roads += value;
    }
    public int GetSchools()
    {
        return schools;
    }
    public int GetFactories()
    {
        return factories;
    }
    public void AddTax(int value)
    {
        income += value;
    }

    public void AssignWorkers(int value)
    {
        freeWorkers -= value;
        workersLabel.text = freeWorkers.ToString();
    }
    public TMP_Text DisplayPopup(Transform location, string text)
    {
        popupInstance = Instantiate(popup, location.position, location.rotation);
        accessablePopup = popupInstance.transform.Find("popup child").gameObject.GetComponent<TextMeshPro>();
        accessablePopup.text = text;
        return accessablePopup;
    }
    public TMP_Text DisplayStaticPopup(Transform location, string text) 
    {
        popupInstance = Instantiate(staticPopup, location.position, location.rotation);
        accessablePopup = popupInstance.transform.Find("popup child").gameObject.GetComponent<TextMeshPro>();
        accessablePopup.text = text;
        return accessablePopup;
    }
    public float WorkerSurplus()
    {
        return ((happiness/10) * freeWorkers * ((schools / 5)+1) * ((roads/20) + 1)) / ((factories*2) + (parks/2) + offices + fireStations + hospitals + policeStations + 1);
    }
    private void Update()
    {
        happiness = Mathf.RoundToInt(((schools / 5) + parks + ((fireStations * hospitals * policeStations*2) + 1 + (roads / 20) +happinessBuff)) / ((factories * 2) + (offices * 1.5f) + ((totalWorkers-freeWorkers)/10) + 1)*100);
        if (happiness > 100)
        {
            happiness = 100;
        }
        incomeLabel.text = "($" + income.ToString() + ")";
        happinessValue.text = happiness.ToString() + "%";

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 5;
            AddMoney(income + Mathf.RoundToInt(offices*WorkerSurplus()*50));
            if (happinessBuff > 0)
            {
                happinessBuff -= 0.00125f;
            }
        }
    }
}
