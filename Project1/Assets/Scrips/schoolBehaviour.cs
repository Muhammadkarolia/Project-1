using UnityEngine;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;

public class schoolBehaviour : MonoBehaviour
{
    public GameObject managementSystem;
    private managementSystem ms;
    public int taxation = 100;
    public GameObject buildingPanel;
    private buildingPanelBehaviour bpb;
    private TextInfo textInfo;
    void Awake()
    {
        textInfo = new CultureInfo("en-UK", false).TextInfo;
        bpb = buildingPanel.GetComponent<buildingPanelBehaviour>();
        ms = managementSystem.GetComponent<managementSystem>();
    }
    void Start()
    {
        ms.AddHappiness(5);
    }
    public void Display()
    {
        bpb.Activate(this.gameObject);
        bpb.buildingName.text = textInfo.ToTitleCase(this.name);
        bpb.productionType.text = "education";
    }
    public void Create()
    {
        ms.AddSchools(1);
    }
    public void Destroy()
    {
        this.gameObject.SetActive(false);
        ms.AddSchools(-1);
    }
}
