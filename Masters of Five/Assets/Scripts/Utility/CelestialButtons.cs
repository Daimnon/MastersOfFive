using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class CelestialButtons : MonoBehaviour //IPointerDownHandler
{
    [SerializeField] private LifeButton LifeButtonInstance;
    [SerializeField] private DeathButton DeathButtonInstance;
    [SerializeField] private ControlButton ControlButtonInstance;
    [SerializeField] private LightButton LightButtonInstance;
    [SerializeField] private DestructionButton DestructionButtonInstance;

    public void HideOtherCelestials()
    {
        if (LifeButtonInstance.IsButtonPressed)
        {
            DeathButtonInstance.GetComponent<Button>().interactable = false;
            ControlButtonInstance.GetComponent<Button>().interactable = false;
            LightButtonInstance.GetComponent<Button>().interactable = false;
            DestructionButtonInstance.GetComponent<Button>().interactable = false;
        }
        else if (DeathButtonInstance.IsButtonPressed)
        {
            LifeButtonInstance.GetComponent<Button>().interactable = false;
            ControlButtonInstance.GetComponent<Button>().interactable = false;
            LightButtonInstance.GetComponent<Button>().interactable = false;
            DestructionButtonInstance.GetComponent<Button>().interactable = false;
        }
        else if (ControlButtonInstance.IsButtonPressed)
        {
            DeathButtonInstance.GetComponent<Button>().interactable = false;
            LifeButtonInstance.GetComponent<Button>().interactable = false;
            LightButtonInstance.GetComponent<Button>().interactable = false;
            DestructionButtonInstance.GetComponent<Button>().interactable = false;
        }
        else if (LightButtonInstance.IsButtonPressed)
        {
            DeathButtonInstance.GetComponent<Button>().interactable = false;
            ControlButtonInstance.GetComponent<Button>().interactable = false;
            LifeButtonInstance.GetComponent<Button>().interactable = false;
            DestructionButtonInstance.GetComponent<Button>().interactable = false;
        }
        else if (DestructionButtonInstance.IsButtonPressed)
        {
            DeathButtonInstance.GetComponent<Button>().interactable = false;
            ControlButtonInstance.GetComponent<Button>().interactable = false;
            LightButtonInstance.GetComponent<Button>().interactable = false;
            LifeButtonInstance.GetComponent<Button>().interactable = false;
        }
    }
}
