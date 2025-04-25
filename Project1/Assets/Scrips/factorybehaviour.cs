using UnityEngine;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;

public class factoryBehaviour : MonoBehaviour
{
    public GameObject managementSystem;
    private managementSystem ms;
    private bool collectable;
    private float timer = 60;
    private float baseProductionTime = 60;
    private float productionTime = 60;
    public string productionType = "wood";
    public int taxation = 20;
    public GameObject buildingPanel;
    private buildingPanelBehaviour bpb;
    private bool displayed;
    private TextInfo textInfo;
    private TMP_Text collectPopup;

    public int level = 1;
    void Awake()
    {
        textInfo = new CultureInfo("en-UK", false).TextInfo;
        bpb = buildingPanel.GetComponent<buildingPanelBehaviour>();
        ms = managementSystem.GetComponent<managementSystem>();
    }
    void Start()
    {
        timer = productionTime;
    }
    void Update()
    {
        productionTime = baseProductionTime / (ms.WorkerSurplus()+1);
        if (timer > productionTime)
        {
            timer = productionTime;
        }
        displayed = this.transform.parent.GetComponent<tileBehaviours>().selected;
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (displayed)
            {
                bpb.timer.text = Mathf.RoundToInt(timer).ToString();
            }  
        }
        else
        {
            if (displayed)
            {
                bpb.timer.text = "Ready to collect!";
                if (!collectable)
                {
                    collectable = true;
                    collectPopup = ms.DisplayStaticPopup(this.transform, "ready to collect!");
                }
            }

        }
    }
    public void Create()
    {
        ms.AddFactories(1);
        ms.AddTax(taxation);
    }
    public void Destroy()
    {
        this.gameObject.SetActive(false);
        ms.AddFactories(-1);
        ms.AddTax(-taxation);
    }
    public void ChangeProduction(string newProductionType)
    {
        if (newProductionType == "wood")
        {
            baseProductionTime = 60;
        }
        if (newProductionType == "glass")
        {
            baseProductionTime = 80;
        }
        if (newProductionType == "metal")
        {
            baseProductionTime = 80;
        }
        if (newProductionType == "brick")
        {
            baseProductionTime = 40;
        }
        productionType = newProductionType;
        Update();
        timer = productionTime;
        bpb.productionType.text = productionType;
    }
    public void Collect()
    {
        if (collectable)
        {
            int collectAmount = Mathf.RoundToInt((level * 50) + ((ms.GetSchools() * 20) / ms.GetFactories()));
            collectable = false;
            if (productionType == "wood")
            {
                ms.AddWood(Mathf.RoundToInt(collectAmount * 1.5f));
            }
            if (productionType == "glass")
            {
                ms.AddGlass(Mathf.RoundToInt(collectAmount*0.5f));
            }
            if (productionType == "metal")
            {
                ms.AddMetal(collectAmount);
            }
            if (productionType == "brick")
            {
                ms.AddBrick(Mathf.RoundToInt(collectAmount * 2.5f));
            }
            timer = productionTime;
            Destroy(collectPopup.transform.parent.gameObject);
            ms.DisplayPopup(this.transform, "+ " + collectAmount.ToString() + " " + productionType);

        }
    }
    public void Upgrade()
    {
        if (ms.GetMoney() >= level * 100)
        {
            ms.AddMoney(-100 * level);
            taxation = Mathf.RoundToInt(taxation*1.2f);
            level += 1;
            ms.AddTax(20);
            bpb.levelLabel.text = "level: " + level.ToString();
            bpb.nextLevelCostLabel.text = "next level: $" + (level * 100).ToString();
            bpb.taxation.text = "$" + taxation.ToString();
        }
    }
    public void Display()
    {
        bpb.Activate(this.gameObject);
        bpb.levelLabel.text = "level: " + level.ToString();
        bpb.nextLevelCostLabel.text = "next level: $" + (level * 100).ToString();
        bpb.buildingName.text = textInfo.ToTitleCase(this.name);
        bpb.productionType.text = productionType;
        bpb.taxation.text = "$" + taxation.ToString();
    }
}
