using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class purchasableTileBehaviour : MonoBehaviour
{
    public Material hilightMaterial;
    public Material selectionMaterial;
    private Material grass;
    private bool hovered;
    private bool selected;
    private Color standardColour;
    private int woodAvailable;
    public GameObject forestTile;
    public GameObject menu;
    public int tileValue;
    public TMP_Text label;
    public GameObject managementSystem;
    private TMP_Text newGuy;
    void Start()
    {
        grass = forestTile.GetComponent<Renderer>().materials[1];
        standardColour = grass.color;
        woodAvailable = Random.Range(700, 1000);
        label.text = "purchase tile?\n($" + tileValue.ToString() + ")";
    }
    void Hover()
    {
        if (!hovered && !selected)
        {
            grass.color = hilightMaterial.color;
            hovered = true;
        }

    }
    void Unhover()
    {
        if (hovered && !selected)
        {
            grass.color = standardColour;
            hovered = false;
        }

    }
    void Select()
    {
        if (!selected)
        {
            grass.color = selectionMaterial.color;
            selected = true;
            menu.SetActive(true);
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
            grass.color = standardColour;
            selected = false;
            menu.SetActive(false);
        }

    }
    public void OnButtonClicked(string button)
    {
        if (button == "purchase")
        {
            if (managementSystem.GetComponent<managementSystem>().GetMoney() >= tileValue)
            {
                forestTile.SetActive(false);
                managementSystem.SendMessage("AddMoney", -tileValue);
                newGuy = managementSystem.GetComponent<managementSystem>().DisplayPopup(this.transform, "-$" + tileValue.ToString());
                print(newGuy.transform.position);
                Unselect();
            }
        }
        else
        {
            Unselect();
        }
        
        
    }
}

