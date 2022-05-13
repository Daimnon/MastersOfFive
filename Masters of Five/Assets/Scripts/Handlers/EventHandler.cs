using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    [SerializeField] private DataHandler _dataHandler;
    [SerializeField] private Battlefield _battlefield;
    
    
    //private LightCard _lightAspect;
    //private DeathCard _deathAspect;
    //private DestructionCard _destructionAspect;
    //private LifeCard _lifeAspect;
    //private ControlCard _controlAspect;

    [SerializeField]
    private Transform _battlefieldP;

    public void StartGame()
    {
        // Draw first card from deck's aspect list from deck to hand
        _dataHandler.DeckData.InitializeGame();
    }

    public void DrawCard()
    {
        _dataHandler.DeckData.DrawCard(_dataHandler.HandData.transform);
    }

    public void DrawTwo()
    {
        _dataHandler.DeckData.DrawTwo(_dataHandler.HandData.CardsInHand, _dataHandler.HandData.transform);
    }

    public void PlaceCard(Draggable currentTarget, List<Card> cardsInField)
    {
        //get current card
        Card cardToField = currentTarget.gameObject.GetComponent<CardDisplay>().CardData;

        //add current card to battlefield
        cardsInField.Add(cardToField);

        //check if works (update: it does)
        print(cardToField.Name);

        //remove placed cards from deck
        _dataHandler.HandData.CardsInHand.Remove(cardToField);

        Action(cardToField);
    }

    public void Action(Card card)
    {
        if (card is LightCard)
            (card as LightCard).Action(this);
        else if (card is DeathCard)
            (card as DeathCard).Action();
        else if (card is DestructionCard)
            (card as DestructionCard).Action();
        else if (card is LifeCard)
            (card as LifeCard).Action();
        else if (card is ControlCard)
            (card as ControlCard).Action();
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
