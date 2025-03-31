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
    public TMP_Text woodValue;
    public TMP_Text brickValue;
    public TMP_Text metalValue;
    public TMP_Text glassValue;
    public TMP_Text moneyValue;
    public GameObject popup;
    private GameObject popupInstance;
    private TMP_Text accessablePopup;
    void Start()
    {
    }
    void AddWood(int value)
    {
        wood += value;
        woodValue.text = wood.ToString();
    }
    void AddMoney(int value)
    {
        money += value;
        moneyValue.text = money.ToString();
    }
    public int GetMoney()
    {
        return money;
    }
    public TMP_Text DisplayPopup(Transform location, string text)
    {
        popupInstance = Instantiate(popup, location.position, location.rotation);
        accessablePopup = popupInstance.transform.Find("popup child").gameObject.GetComponent<TextMeshPro>();
        accessablePopup.text = text;
        return accessablePopup;
    }
}
