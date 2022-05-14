using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Hand : MonoBehaviour, IDropHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private DataHandler _dataHandler;

    public List<Card> CardsInHand;

    public Draggable CurrentCardInHand;
    public Card CurrentCardDataInHand;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Draggable currentCard = eventData.pointerDrag.GetComponent<Draggable>();

        CurrentCardInHand = currentCard;
        CurrentCardDataInHand = currentCard.GetComponent<CardDisplay>().CardData;
    }

    private void Update()
    {
        print($"Is Sacrifising is {_dataHandler.IsSacrificing}");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _dataHandler.TombData.Sacrifice(eventData);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        print("card Placed");

        if (CurrentCardInHand.IsCardInHand)
            CurrentCardInHand.ParentToReturn = transform;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
