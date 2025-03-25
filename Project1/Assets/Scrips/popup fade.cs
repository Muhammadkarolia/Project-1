using UnityEngine;
using TMPro;

public class popupfade : MonoBehaviour
{
    private float opacity;
    private Color popupColour;
    public TMP_Text popup;
    void Start()
    {
        opacity = 1f;
    }
    void Update()
    {
        if (opacity > 0)
        {
            popupColour = new Color(1, 1, 1, opacity);
            popup.color = popupColour;
            opacity -= Time.deltaTime * 0.3f;
        }
    }
}
