using UnityEngine;

public class tileBehaviours : MonoBehaviour
{
    public Material hilightMaterial;
    public Material selectionMaterial;

    private GameObject concreteTile;
    private GameObject treeTrunk;
    private GameObject treeLeaves;
    private bool hovered;
    private bool selected;
    private Material standardMaterial;
    private GameObject buildingObject;
    private GameObject tile;
    private GameObject currentBuilding;
    private bool occupied;
    void Awake()
    {
        tile = transform.Find("natural tile").gameObject;
        concreteTile = transform.Find("concrete tile").gameObject;
        treeTrunk = transform.Find("tree trunk").gameObject;
        treeLeaves = transform.Find("tree leaves").gameObject;
    }
    void Hover()
    {
        if (!hovered && !selected)
        {
            standardMaterial = tile.GetComponent<Renderer>().material;
            tile = transform.Find("natural tile").gameObject;
            tile.GetComponent<Renderer>().material = hilightMaterial;
            hovered = true;
        }
        
    }
    void Unhover()
    {
        if (hovered && !selected)
        {
            tile.GetComponent<Renderer>().material = standardMaterial;
            hovered = false;
        }

    }
    void Select()
    {
        if (!selected)
        {
            tile.GetComponent<Renderer>().material = selectionMaterial;
            selected = true;
        }
        else
        {
            Unselect();
        }

    }
    void Unselect()
    {
        if (selected)
        {
            tile.GetComponent<Renderer>().material = standardMaterial;
            selected = false;
        }

    }
    void ConstructBuilding(string building)
    {
        if (selected && !occupied)
        {
            currentBuilding = transform.Find(building).gameObject;
            currentBuilding.SetActive(true);
            treeTrunk.SetActive(false);
            treeLeaves.SetActive(false);
            tile.SetActive(false);
            tile = concreteTile;
            standardMaterial = tile.GetComponent<Renderer>().material;
            tile.SetActive(true);
            occupied = true;
            selected = false;
            hovered = false;
        }
    }
    void DeconstructBuilding()
    {
        if (selected && occupied)
        { 
            currentBuilding.SetActive(false);
            occupied = false;
        }
    }
}
