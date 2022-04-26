using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class Battlefield : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Hand _hand;

    public Image _shitHappened;

    public List<Card> CardsInField;

    private void Start()
    {
        _shitHappened.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Draggable currentCard = eventData.pointerDrag.GetComponent<Draggable>();

        if (currentCard != null)
        {
            currentCard.ParentToReturnPlaceholder = transform;
            currentCard.IsCardInHand = false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        print("card Placed");

        Draggable currentCard = eventData.pointerDrag.GetComponent<Draggable>();

        if (currentCard != null)
        {
            currentCard.ParentToReturn = transform;
            currentCard.IsCardInHand = false;
            PlaceCard(currentCard, CardsInField);
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

    public void PlaceCard(Draggable currentCard, List<Card> cardsInField)
    {
        //get current card
        Card cardToField = currentCard.gameObject.GetComponent<CardDisplay>().CardData;

        //add current card to battlefield
        cardsInField.Add(cardToField);

        //check if works (update: it does)
        print(cardToField.Name);

        //remove placed cards from deck
        _hand.CardsInHand.Remove(cardToField);

        Action(cardToField);
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

        _shitHappened.gameObject.SetActive(true);
    }
}
