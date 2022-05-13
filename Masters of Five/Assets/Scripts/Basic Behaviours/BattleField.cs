using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Battlefield : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private EventHandler _eventHandler;

    public List<Card> CardsInField;

    public Draggable CurrentCardInBattlefield;
    public Card CurrentCardDataInBattlefield;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Draggable currentCard = eventData.pointerDrag.GetComponent<Draggable>();

        CurrentCardInBattlefield = currentCard;
        CurrentCardDataInBattlefield = currentCard.GetComponent<CardDisplay>().CardData;

        if (CurrentCardInBattlefield != null)
        {
            CurrentCardInBattlefield.ParentToReturnPlaceholder = transform;
            CurrentCardInBattlefield.IsCardInHand = false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (CurrentCardInBattlefield != null)
        {
            CurrentCardInBattlefield.ParentToReturn = transform;
            CurrentCardInBattlefield.IsCardInHand = false;
            _eventHandler.BattlefieldPlaceCard(CurrentCardInBattlefield);
            CurrentCardInBattlefield = null;
            CurrentCardDataInBattlefield = null;
            
            print("card Placed");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        if (CurrentCardInBattlefield != null && CurrentCardInBattlefield.ParentToReturnPlaceholder == transform)
        {
            CurrentCardInBattlefield.ParentToReturnPlaceholder = transform;
            CurrentCardInBattlefield.IsCardInHand = false;
        }
    }
}
