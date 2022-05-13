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

    public void Sacrifice(DataHandler dataHandler, Draggable currentTarget)
    {
        dataHandler.IsSacrificing = true;

        //get current card
        Card cardToTomb = currentTarget.gameObject.GetComponent<CardDisplay>().CardData;

        //add current card to tomb
        CardsInTomb.Add(cardToTomb);

        //check if works)
        print(cardToTomb.Name);

        dataHandler.HandData.CardsInHand.Remove(cardToTomb);



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
