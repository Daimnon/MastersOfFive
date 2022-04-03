using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class BattleField : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Draggable currentCard = eventData.pointerDrag.GetComponent<Draggable>();

        if (currentCard != null)
        {
            currentCard.ParentToReturnPlaceholder = transform;
            currentCard.IsCardInHand = false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        print("card Placed");

        Draggable currentCard = eventData.pointerDrag.GetComponent<Draggable>();

        if (currentCard != null)
        {
            currentCard.ParentToReturn = transform;
            currentCard.IsCardInHand = false;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Draggable currentCard = eventData.pointerDrag.GetComponent<Draggable>();

        if (currentCard != null && currentCard.ParentToReturnPlaceholder == transform)
        {
            currentCard.ParentToReturnPlaceholder = transform;
            currentCard.IsCardInHand = false;
        }
    }
}
