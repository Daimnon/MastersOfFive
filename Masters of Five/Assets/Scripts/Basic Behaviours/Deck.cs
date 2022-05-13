using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private int _maxDeckSize = 25, _currentDeckSize;

    [SerializeField] private DataHandler _dataHandler;

    [SerializeField]
    private Card _lightCard, _deathCard, _destructionCard, _lifeCard, _controlCard;

    [SerializeField]
    private GameObject _cardPrefab;

    [SerializeField]
    private List<Card> _aspectsInDeck = new List<Card>(25);

    private void Start()
    {
        _aspectsInDeck.Clear();

        for (int i = 0; i < 5; i++)
        {
            _aspectsInDeck.Add(_lightCard);
            _aspectsInDeck.Add(_deathCard);
            _aspectsInDeck.Add(_destructionCard);
            _aspectsInDeck.Add(_lifeCard);
            _aspectsInDeck.Add(_controlCard);
        }
        //randomize _aspectsInDeck list
        for (int i = 0; i < _aspectsInDeck.Count; i++)
        {
            Card temp = _aspectsInDeck[i];
            int randomIndex = UnityEngine.Random.Range(i, _aspectsInDeck.Count);
            _aspectsInDeck[i] = _aspectsInDeck[randomIndex];
            _aspectsInDeck[randomIndex] = temp;
        }
    }

    public void InitializeGame()
    {
        //get top 4 cards in deck
        List<Card> cardsToHand = _aspectsInDeck.GetRange(0, 4);

        //add said cards to hand
        _dataHandler.HandData.CardsInHand.AddRange(cardsToHand);

        //loops through said cards's data, reads it and creates a prefab based on that data in the hand
        foreach (Card card in cardsToHand)
        {
            _cardPrefab.GetComponent<CardDisplay>().CardData = card;
            Instantiate(_cardPrefab, _dataHandler.HandData.transform);

            //check if works (update: it does)
            print(card.Name);
        }

        //remove drawn cards from deck
        _aspectsInDeck.RemoveRange(0, 4);
        _currentDeckSize -= 4;
    }

    public void DrawCard()
    {
        //get top card in deck & adds it to the hand
        _dataHandler.HandData.CardsInHand.Add(_aspectsInDeck[0]);

        //reads said card data and creates a prefab based on that data in the hand
        _cardPrefab.GetComponent<CardDisplay>().CardData = _aspectsInDeck[0];
        Instantiate(_cardPrefab, _dataHandler.HandData.transform);
        
        //check if works (update: it does)
        print(_aspectsInDeck[0].Name);

        _aspectsInDeck.RemoveAt(0);
        _currentDeckSize --;
    }

    public void DrawTwo()
    {
        //get top 2 cards in deck
        List<Card> cardsToHand = _aspectsInDeck.GetRange(0, 2);

        //add said cards to hand
        _dataHandler.HandData.CardsInHand.AddRange(cardsToHand);

        //loops through said cards's data, reads it and creates a prefab based on that data in the hand
        foreach (Card card in cardsToHand)
        {
            _cardPrefab.GetComponent<CardDisplay>().CardData = card;
            Instantiate(_cardPrefab, _dataHandler.HandData.transform);

            //check if works (update: it does)
            print(card.Name);
        }

        //remove drawn cards from deck
        _aspectsInDeck.RemoveRange(0, 2);
        _currentDeckSize -= 2;
    }
}
