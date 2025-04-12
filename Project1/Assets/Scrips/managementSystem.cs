using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class managementSystem : MonoBehaviour
{
    private int wood = 0;
    private int brick = 0;
    private int metal = 0;
    private int glass = 0;
    private int money = 300;
    private int happiness = 0;
    public TMP_Text woodValue;
    public TMP_Text brickValue;
    public TMP_Text metalValue;
    public TMP_Text glassValue;
    public TMP_Text moneyValue;
    public TMP_Text happinessValue;
    public GameObject popup;
    public GameObject staticPopup;
    private GameObject popupInstance;
    private TMP_Text accessablePopup;
    void Start()
    {
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

}
