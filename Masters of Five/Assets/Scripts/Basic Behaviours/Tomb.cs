using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class Tomb : MonoBehaviour, IDropHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Data Script")]
    [SerializeField] private DataHandler _myDataHandler;
    [SerializeField] private DataHandler _opponentDataHandler;
    [SerializeField] private EventHandler _myEventHandler;
    [SerializeField] private GameObject _tombWindow, _tombWindowContent;

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
        //get current card
        CardData cardToTomb = eventData.pointerDrag.GetComponent<CardDisplay>().CardData;

        //add current card to tomb
        _myDataHandler.TombData.CardsInTomb.Add(cardToTomb);

        //check if works
        print(cardToTomb.Name);

        //remove placed cards from hand
        _myDataHandler.HandData.CardsInHand.Remove(cardToTomb);

        eventData.pointerDrag.transform.SetParent(_tombWindowContent.transform);
        eventData.pointerDrag.AddComponent<Button>();
        Button cardBtn = eventData.pointerDrag.GetComponent<Button>();
        cardBtn.onClick.AddListener(Revive);

        _myDataHandler.IsSacrificing = false;
        _myDataHandler.SacrificeOverlay.SetActive(false);


    }

    public void CardToDestroy(PointerEventData eventData)
    {
        //_myEventHandler.TargetLine.SetPosition(0, _myDataHandler.LastPlacedCardOnBattelfield.transform.position);
        //_myEventHandler.TargetLine.SetPosition(1, eventData.position);
        print("Tried drawing line");
        //get current card
        CardData cardToTomb = eventData.pointerDrag.GetComponent<CardDisplay>().CardData;

        //add current card to tomb
        _opponentDataHandler.TombData.CardsInTomb.Add(cardToTomb);

        //check if works
        print(cardToTomb.Name);

        //remove placed cards from battlefield
        _opponentDataHandler.BattlefieldData.CardsInField.Remove(cardToTomb);

        eventData.pointerDrag.transform.SetParent(_tombWindowContent.transform);
        eventData.pointerDrag.AddComponent<Button>();
        Button cardBtn = eventData.pointerDrag.GetComponent<Button>();
        cardBtn.onClick.AddListener(Revive);


        _myDataHandler.IsDestroying = false;
    }

    public void Revive()
    {
        Debug.Log($"Attemting Revive: {EventSystem.current.currentSelectedGameObject.name}");

        if (_myDataHandler.IsReviving)
        {
            GameObject currentCard = EventSystem.current.currentSelectedGameObject;
            CardData cardToHand = currentCard.GetComponent<CardDisplay>().CardData;
            currentCard.transform.SetParent(_myDataHandler.HandData.transform);
            _myDataHandler.HandData.CardsInHand.Add(cardToHand);
            CardsInTomb.Remove(cardToHand);
            Destroy(currentCard.GetComponent<Button>());

            _myDataHandler.IsReviving = false;
            CloseSearchTomb();

            Debug.Log($"Revived: {cardToHand.name}");
            return;
        }
    }

    public void SearchTomb()
    {
        _tombWindow.SetActive(true);
    }

    public void CloseSearchTomb()
    {
        _tombWindow.SetActive(false);
    }
}
