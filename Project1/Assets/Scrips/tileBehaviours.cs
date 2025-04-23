using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class tileBehaviours : MonoBehaviour
{
    public Material hilightMaterial;
    public Material selectionMaterial; 
    public Material concrete;
    private GameObject tree;
    private bool hovered;
    public bool selected;
    public GameObject parkTile;
    private Material standardMaterial;
    private GameObject buildingObject;
    public GameObject tile;
    private GameObject currentBuilding;
    private int woodAvailable;
    private bool occupied;
    private bool currentlyDisplaying;
    public GameObject managementSystem;
    private managementSystem ms;
    public GameObject buildingPanel;
    private Dictionary<string, int[]> buildings = new Dictionary<string, int[]>();
    private int[] house = {30,50,10,100,250};//wood metal glass brick money
    private int[] office = { 80, 200, 200, 400, 1000 };
    private int[] school = { 60, 150, 40, 300, 1750 };
    private int[] factory = { 150, 600, 200, 1000, 2500 };
    private int[] hospital = { 40, 250, 100, 200, 1500 };
    private int[] policeStation = { 40, 250, 80, 200, 1500 };
    private int[] fireStation = { 40, 250, 100, 200, 1500 };
    private int[] park = { 100, 10, 10, 10, 2000 };
    private int woodRequired;
    private int metalRequired;
    private int glassRequired;
    private int brickRequired;
    private int moneyRequired;
    void Awake()
    {
        ms = managementSystem.GetComponent<managementSystem>();
        buildings.Add("house",house);
        buildings.Add("park", park);
        buildings.Add("office", office);
        buildings.Add("school", school);
        buildings.Add("factory", factory);
        buildings.Add("hospital", hospital);
        buildings.Add("police station", policeStation);
        buildings.Add("fire station", fireStation);
        woodAvailable = Random.Range(20, 100);
        if (woodAvailable <75)
        {
            tree = transform.Find("tree").gameObject;
        }
        else
        {
            tree = transform.Find("large tree").gameObject;
        }
        tree.SetActive(true);
            
    }
    public void Hover()
    {
        if (!hovered && !selected)
        {
            standardMaterial = tile.GetComponent<Renderer>().material;
            tile.GetComponent<Renderer>().material = hilightMaterial;
            parkTile.GetComponent<Renderer>().material = hilightMaterial;
            hovered = true;
        }
        
    }
    public void Unhover()
    {
        if (hovered && !selected)
        {
            tile.GetComponent<Renderer>().material = standardMaterial;
            parkTile.GetComponent<Renderer>().material = standardMaterial;
            hovered = false;
        }

    }
    public void Select()
    {
        if (!selected)
        {
            tile.GetComponent<Renderer>().material = selectionMaterial;
            parkTile.GetComponent<Renderer>().material = selectionMaterial;
            selected = true;
            if (occupied)
            { 
                currentBuilding.SendMessage("Display");
                currentlyDisplaying = true;
                
            }
        }
        else
        {
            Unselect();
        }

    }
    public void Unselect()
    {
        if (selected)
        {
            tile.GetComponent<Renderer>().material = standardMaterial;
            parkTile.GetComponent<Renderer>().material = standardMaterial;
            selected = false;
            if (currentlyDisplaying)
            {
                buildingPanel.GetComponent<buildingPanelBehaviour>().Activate();
                currentlyDisplaying = false;
            }
        }

    }
    public void ConstructBuilding(string building)
    {
        if (selected && !occupied)
        {
            woodRequired = buildings[building][0];
            metalRequired = buildings[building][1];
            glassRequired = buildings[building][2];
            brickRequired = buildings[building][3];
            moneyRequired = buildings[building][4];
            if (woodRequired <= ms.GetWood()+woodAvailable && metalRequired <= ms.GetMetal() && glassRequired <= ms.GetGlass() &&
                brickRequired <= ms.GetBrick() && moneyRequired <= ms.GetMoney())
            {
                if (woodAvailable > 0)
                {
                    managementSystem.GetComponent<managementSystem>().DisplayPopup(this.transform, "+ " + woodAvailable.ToString() + " Wood");
                    managementSystem.GetComponent<managementSystem>().AddWood(woodAvailable);
                    woodAvailable = 0;
                }
                ms.AddWood(-woodRequired);
                ms.AddMetal(-metalRequired);
                ms.AddGlass(-glassRequired);
                ms.AddBrick(-brickRequired);
                ms.AddMoney(-moneyRequired);
                currentBuilding = transform.Find(building).gameObject;
                currentBuilding.SetActive(true);
                if (currentBuilding.name != "park")
                {
                    standardMaterial = concrete;
                }
                else
                {
                    tile.GetComponent<MeshRenderer>().enabled = false;
                }
                currentBuilding.SendMessage("Create");
                tree.SetActive(false);
                occupied = true;
                Unselect();
                hovered = false;

            }
            
        }
    }
    void DeconstructBuilding()
    {
        if (selected)
        { 
            if (occupied)
            {
                if (currentBuilding.name == "park")
                {
                    tile.GetComponent<MeshRenderer>().enabled = true;
                }
                currentBuilding.SendMessage("Destroy");
                occupied = false;
            }
            else
            {
                if (woodAvailable > 0)
                {
                    tree.SetActive(false);
                    managementSystem.GetComponent<managementSystem>().AddWood(woodAvailable);
                    managementSystem.GetComponent<managementSystem>().DisplayPopup(this.transform, "+ " + woodAvailable.ToString() + " Wood");
                    woodAvailable = 0;
                }
            }
            Unselect();

        }
    }
}
