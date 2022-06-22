using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class LightButton : MonoBehaviour, IPointerDownHandler
{
    public bool IsButtonPressed = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        IsButtonPressed = true;
    }
}
