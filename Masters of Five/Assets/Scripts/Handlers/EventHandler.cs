using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    [SerializeField] private DataHandler _dataHandler;

    public void StartGame()
    {
        // Draw first card from deck's aspect list from deck to hand
        _dataHandler.DeckData.InitializeGame();
    }

    public void DrawCard()
    {
        _dataHandler.DeckData.DrawCard();
    }

    public void DrawTwo()
    {
        _dataHandler.DeckData.DrawTwo();
    }

    // not ready
    public void Sacrifice()
    {
        //get current card
        Card cardToTomb = _dataHandler.BattlefieldData.CurrentCardDataInBattlefield;

        //add current card to tomb
        _dataHandler.TombData.CardsInTomb.Add(cardToTomb);

        //check if works
        print(cardToTomb.Name);

        //remove placed cards from hand
        _dataHandler.HandData.CardsInHand.Remove(cardToTomb);

        Action(cardToTomb);
    }

    public void BattlefieldPlaceCard(Draggable currentTarget)
    {
        //get current card
        Card cardToField = currentTarget.gameObject.GetComponent<CardDisplay>().CardData;

        //add current card to battlefield
        _dataHandler.BattlefieldData.CardsInField.Add(cardToField);

        //check if works
        print(cardToField.Name);

        //remove placed cards from hand
        _dataHandler.HandData.CardsInHand.Remove(cardToField);

        Action(cardToField);
    }

    public void Action(Card card)
    {
        if (card is LightCard)
            (card as LightCard).Action(this);
        else if (card is DeathCard)
            (card as DeathCard).Action(this);
        else if (card is DestructionCard)
            (card as DestructionCard).Action(this);
        else if (card is LifeCard)
            (card as LifeCard).Action(this);
        else if (card is ControlCard)
            (card as ControlCard).Action(this);
    }

    public void SupremeAction(Card card)
    {
        if (card is LightCard)
            (card as LightCard).SupremeAction();
        else if (card is DeathCard)
            (card as DeathCard).SupremeAction();
        else if (card is DestructionCard)
            (card as DestructionCard).SupremeAction();
        else if (card is LifeCard)
            (card as LifeCard).SupremeAction();
        else if (card is ControlCard)
            (card as ControlCard).SupremeAction();
    }

    public void SecondaryAction(Card card)
    {
        if (card is LightCard)
            (card as LightCard).SecondaryAction();
        else if (card is DeathCard)
            (card as DeathCard).SecondaryAction();
        else if (card is DestructionCard)
            (card as DestructionCard).SecondaryAction();
        else if (card is LifeCard)
            (card as LifeCard).SecondaryAction();
        else if (card is ControlCard)
            (card as ControlCard).SecondaryAction();
    }
}
