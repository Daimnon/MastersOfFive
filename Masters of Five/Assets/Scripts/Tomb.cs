using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class Tomb : MonoBehaviour, IDropHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Data Script")]
    [SerializeField] private DataHandler _dataHandler;

    [Header("AspectList")]
    public List<CardData> CardsInTomb;

    [Header("CurrentAspects")]
    public Card CurrentCardInHand;
    public CardData CurrentCardDataInTomb;


    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
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
            CardData cardToTomb = eventData.pointerDrag.GetComponent<CardDisplay>().CardData;

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
