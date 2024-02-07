using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_ToolTIp : MonoBehaviour
{
    [SerializeField] float xLimit = 960;
    [SerializeField] float yLimit = 540;

    [SerializeField] float xOffset = 150;
    [SerializeField] float yOffset = 150;

    public void AdjustPosition()
    {
        Vector2 mousePosition = Input.mousePosition;

        float newXoffset = 0;
        float newYeffset = 0;

        if (mousePosition.x > xLimit)
            newXoffset = -xOffset;
        else
            newXoffset = xOffset;
        if (mousePosition.y > yLimit)
            newYeffset = -yOffset;
        else
            newYeffset = yOffset;

        transform.position = new Vector2(mousePosition.x + newXoffset, mousePosition.y + newYeffset);
    }

    public void AdjustFontSize(TextMeshProUGUI _text)
    {
        if(_text.text.Length >12)
        {
            _text.fontSize = _text.fontSize * .8f;
        }
    }
}
