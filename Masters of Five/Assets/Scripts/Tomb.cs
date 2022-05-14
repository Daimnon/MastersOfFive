using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Tomb : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private DataHandler _dataHandler;

    public List<Card> CardsInTomb;

    public Draggable CurrentCardInHand;
    public Card CurrentCardDataInTomb;


    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void CardToSacrifice(PointerEventData eventData)
    {
        if (!_dataHandler.IsSacrificing)
            return;

        else if (_dataHandler.IsSacrificing)
        {
            //get current card
            Card cardToTomb = eventData.pointerDrag.GetComponent<CardDisplay>().CardData;

            //add current card to tomb
            _dataHandler.TombData.CardsInTomb.Add(cardToTomb);

            //check if works
            print(cardToTomb.Name);

            //remove placed cards from hand
            _dataHandler.HandData.CardsInHand.Remove(cardToTomb);

            Destroy(eventData.pointerDrag);
            _dataHandler.IsSacrificing = false;
        }
    }

    private void Search()
    {
        /* Player should be able to vieww Tomb at all times
            this is correct for all players to all tombs
            which means that Tomb should be accesible
            by all player at any point of the game
        */
    }
}
