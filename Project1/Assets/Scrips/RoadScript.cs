using UnityEngine;

public class RoadScript : MonoBehaviour
{
    public Material hilightMaterial;
    public Material selectionMaterial;
    public Material hilightMaterial2;
    public GameObject managementSystem;

    private managementSystem ms;
    private bool selected;
    private bool hovered;
    public GameObject roadSurface;
    private Material standardMaterial;
    private bool occupied;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ms = managementSystem.GetComponent<managementSystem>();
        standardMaterial = roadSurface.GetComponent<Renderer>().material;
    }
    void Hover()
    {
        if (!hovered && !selected)
        {
            if (!occupied)
            {
                roadSurface.GetComponent<Renderer>().material = hilightMaterial;
                roadSurface.SetActive(true);
            }
            else
            {
                roadSurface.GetComponent<Renderer>().material = hilightMaterial2;
            }
            hovered = true;
        }

    }
    void Unhover()
    {
        if (hovered && !selected)
        {
            if (!occupied)
            {
                roadSurface.SetActive(false);
            }
            roadSurface.GetComponent<Renderer>().material = standardMaterial;
            hovered = false;
        }

    }
    void Select()
    {
        if (!selected)
        {
            roadSurface.GetComponent<Renderer>().material = selectionMaterial;
            roadSurface.SetActive(true);
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
            roadSurface.GetComponent<Renderer>().material = standardMaterial;
            roadSurface.SetActive(false);
            selected = false;
        }
    }
    void ConstructRoad()
    {
        if (selected && !occupied)
        {
            ms.AddRoads(1);
            ms.AddTax(-1);
            roadSurface.SetActive(true);
            roadSurface.GetComponent<Renderer>().material = standardMaterial;
            occupied = true;
            selected = false;
            hovered = false;
        }
    }
    void DeconstructBuilding()
    {
        if (selected && occupied)
        {
            ms.AddRoads(-1);
            ms.AddTax(1);
            roadSurface.SetActive(false);
            occupied = false;
            selected = false;
            hovered = false;
        }
    }
}
