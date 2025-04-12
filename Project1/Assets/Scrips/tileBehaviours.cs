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
    private bool selected;
    private Material standardMaterial;
    private GameObject buildingObject;
    public GameObject tile;
    private GameObject currentBuilding;
    private int woodAvailable;
    private bool occupied;
    private bool currentlyDisplaying;
    public GameObject managementSystem;
    public GameObject buildingPanel;
    void Start()
    {
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
            hovered = true;
        }
        
    }
    public void Unhover()
    {
        if (hovered && !selected)
        {
            tile.GetComponent<Renderer>().material = standardMaterial;
            hovered = false;
        }

    }
    public void Select()
    {
        if (!selected)
        {
            tile.GetComponent<Renderer>().material = selectionMaterial;
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
            selected = false;
            if (currentlyDisplaying)
            {
                buildingPanel.GetComponent<buildingPanelBehaviour>().Activate();
                currentlyDisplaying = false;
            }
        }

    }
    void ConstructBuilding(string building)
    {
        if (selected && !occupied)
        {
            if (woodAvailable > 0)
            {

                managementSystem.GetComponent<managementSystem>().DisplayPopup(this.transform, "+ " + woodAvailable.ToString() + " Wood");
                managementSystem.GetComponent<managementSystem>().AddWood(woodAvailable);
                woodAvailable = 0;
            }
            currentBuilding = transform.Find(building).gameObject;
            currentBuilding.SetActive(true);
            tree.SetActive(false);
            standardMaterial = concrete;
            occupied = true;
            Unselect();
            hovered = false;
        }
    }
    void DeconstructBuilding()
    {
        if (selected)
        { 
            if (occupied)
            {
                currentBuilding.SetActive(false);
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
