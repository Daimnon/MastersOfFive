using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    [SerializeField] private Deck _deck;
    [SerializeField] private Hand _hand;
    [SerializeField] private Battlefield _battlefield;
    
    
    //private LightCard _lightAspect;
    //private DeathCard _deathAspect;
    //private DestructionCard _destructionAspect;
    //private LifeCard _lifeAspect;
    //private ControlCard _controlAspect;

    [SerializeField]
    private Transform _handP, _battlefieldP;

    public void StartGame()
    {
        // Draw first card from deck's aspect list from deck to hand
        _deck.InitializeGame(_hand.CardsInHand, _handP);
    }

    public void DrawCard()
    {
        _deck.DrawCard(_hand.CardsInHand, _handP);
        _battlefield._shitHappened.gameObject.SetActive(false);
    }

    public void DrawTwo()
    {
        _deck.DrawTwo(_hand.CardsInHand, _handP);
    }

    public void Action(Card card)
    {
        if (card is LightCard)
            (card as LightCard).Action();
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
