using DoozyUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenIdentifier : MonoBehaviour
{
    public string elementName, elemetCat;
    private void Reset()
    {
        var element = GetComponent<UIElement>();
        if (element != null)
        {
            elementName = element.elementName;
            elemetCat = element.elementCategory;
        }
    }
}
