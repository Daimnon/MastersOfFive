using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class Battlefield : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private EventHandler _eventHandler;
    [SerializeField] private Hand _hand;

    private Draggable _currentTarget;
    private Card _currentCard;

    public List<Card> CardsInField;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        _currentTarget = eventData.pointerDrag.GetComponent<Draggable>();
        _currentCard = eventData.pointerDrag.GetComponent<CardDisplay>().CardData;
        //Draggable currentCard = eventData.pointerDrag.GetComponent<Draggable>();

        if (_currentTarget != null)
        {
            _currentTarget.ParentToReturnPlaceholder = transform;
            _currentTarget.IsCardInHand = false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (_currentTarget != null)
        {
            _currentTarget.ParentToReturn = transform;
            _currentTarget.IsCardInHand = false;
            _eventHandler.PlaceCard(_currentTarget, CardsInField);
            _currentTarget = null;
            _currentCard = null;
            
            print("card Placed");
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
