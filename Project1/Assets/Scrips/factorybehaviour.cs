using UnityEngine;
using System.Globalization;

public class factoryBehaviour : MonoBehaviour
{
    public GameObject managementSystem;
    private managementSystem ms;
    private bool collectable;
    private float timer = 60;
    private float productionTime = 60;
    public string productionType = "wood";
    public int taxation = 100;
    public GameObject buildingPanel;
    private buildingPanelBehaviour bpb;
    private bool displayed;
    private TextInfo textInfo;
    void Start()
    {
        textInfo = new CultureInfo("en-UK", false).TextInfo;
        bpb = buildingPanel.GetComponent<buildingPanelBehaviour>();
        ms = managementSystem.GetComponent<managementSystem>();
        ms.AddHappiness(-5);
    }
    void Update()
    {
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
            if (!collectable)
            {
                bpb.timer.text = "Ready to collect!";
                collectable = true;
                ms.DisplayStaticPopup(this.transform, "ready to collect!");
            }

        }
        taxation = 100 + (ms.GetHappiness());
    }
    public void ChangeProduction(string newProductionType)
    {
        if (newProductionType == "wood")
        {
            productionTime = 60;
        }
        if (newProductionType == "glass")
        {
            productionTime = 80;
        }
        if (newProductionType == "metal")
        {
            productionTime = 100;
        }
        if (newProductionType == "brick")
        {
            productionTime = 120;
        }
        productionType = newProductionType;
        timer = productionTime;
        bpb.productionType.text = productionType;
    }
    public void Collect()
    {
        if (collectable)
        {
            collectable = false;
            if (productionType == "wood")
            {
                ms.AddWood(10);
            }
            if (productionType == "glass")
            {
                ms.AddGlass(10);
            }
            if (productionType == "metal")
            {
                ms.AddMetal(10);
            }
            if (productionType == "brick")
            {
                ms.AddBrick(10);
            }
            timer = productionTime;

        }
    }
    public void Display()
    {
        bpb.Activate(this.gameObject);
        displayed = true;
        bpb.buildingName.text = textInfo.ToTitleCase(this.name);
        bpb.productionType.text = productionType;
    }
}
