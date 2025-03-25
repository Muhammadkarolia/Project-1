using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class purchasableTileBehaviour : MonoBehaviour
{
    public Material hilightMaterial;
    public Material selectionMaterial;
    private bool hovered;
    private bool selected;
    private Material standardMaterial;
    private int woodAvailable;
    public TMP_Text popup;
    private TMP_Text popupInstance;
    void Start()
    {
        woodAvailable = Random.Range(700, 1000);
    }
    void Hover()
    {
        if (!hovered && !selected)
        {
            standardMaterial = this.GetComponent<Renderer>().material;
            this.GetComponent<Renderer>().material = hilightMaterial;
            hovered = true;
        }

    }
    void Unhover()
    {
        if (hovered && !selected)
        {
            this.GetComponent<Renderer>().material = standardMaterial;
            hovered = false;
        }

    }
    void Select()
    {
        if (!selected)
        {
            this.GetComponent<Renderer>().material = selectionMaterial;
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
            this.GetComponent<Renderer>().material = standardMaterial;
            selected = false;
        }

    }
}

