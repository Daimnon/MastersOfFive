using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private int _maxDeckSize = 25, _currentDeckSize;

    //private Aspect[] _aspectsInDeck = new Aspect[25];
    //private Aspect[] _topTwoAspectsInDeck = new Aspect[2];
    [SerializeField]
    private GameObject _cardPrefab;

    [SerializeField]
    private List<Card> _aspectsInDeck = new List<Card>(25);

    private System.Random _rand;


    private void Start()
    {
        _rand = new System.Random();
        _aspectsInDeck.OrderBy(randomAspectsInDeck => _rand.Next(0, 25));
    }

    public void InitializeGame(IEnumerable startingHand, Transform hand)
    {
        startingHand = _aspectsInDeck.Take(4);

        foreach (Card card in startingHand)
        {
            Instantiate(_cardPrefab, hand);

            //check if works (update: it does)
            print(card.Name);
        }
    }

    //public Card GetTopAspectInDeck(IEnumerable startingHand, Transform hand)
    //{
    //    // Find top Aspect in deck
    //    startingHand = _aspectsInDeck.Take(0);
    //
    //    return _aspectsInDeck[_aspectsInDeck.Length/* -1?*/];
    //}

    /*
    private Aspect[] ShowTopTwoAspectsInDeck()
    {
        // Should make use of "GetTopAspectInDeck" in order to find the card to draw
        // Build around or dispose of the sample code I created below :)

        Aspect aspect1, aspect2;

        for (int i = 0; i < _aspectsInDeck.Length; i++)
        {
            if (i < 1)
            {
                aspect1 = GetTopAspectInDeck();
                _topTwoAspectsInDeck[0] = aspect1;
            }

            else if (i < 2)
            {
                aspect2 = GetTopAspectInDeck();
                _topTwoAspectsInDeck[1] = aspect2;
            }

            else
            {
                print("Couldn't resolve: 'ShowTwoTopAspectsInDeck()'");
                break;
            }
        }

        return _topTwoAspectsInDeck;
    }
    */
}
