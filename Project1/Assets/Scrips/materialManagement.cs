using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class materialManagement : MonoBehaviour
{
    private int wood = 0;
    private int brick = 0;
    private int metal = 0;
    private int glass = 0;
    public TMP_Text woodValue;
    public TMP_Text brickValue;
    public TMP_Text metalValue;
    public TMP_Text glassValue;
    void Start()
    {
    }
    void addWood(int value)
    {
        wood = wood + value;
        woodValue.text = wood.ToString();
    }
}
