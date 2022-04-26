using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Hand : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public List<Card> CardsInHand;

    public void OnDrop(PointerEventData eventData)
    {
        print("card Placed");

        Draggable currentCard = eventData.pointerDrag.GetComponent<Draggable>();

        if (currentCard != null)
            if (currentCard.IsCardInHand)
                currentCard.ParentToReturn = transform;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
