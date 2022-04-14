using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private int _maxDeckSize = 25, _currentDeckSize;
    
    private Aspect[] _aspectsInDeck = new Aspect[25];
    private Aspect[] _topTwoAspectsInDeck = new Aspect[2];
    private Aspect Draw()
    {
        // Make Drawing from deck to hand
        // Should make use of "GetTopAspectInDeck" in order to find the card to draw

        return GetTopAspectInDeck();
    }

    private Aspect GetTopAspectInDeck()
    {
        // Find top Aspect in deck
        return _aspectsInDeck[_aspectsInDeck.Length/* -1?*/];
    }

    private Aspect[] ShowTopTwoAspectsInDeck()
    {
        // Should make use of "GetTopAspectInDeck" in order to find the card to draw
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
}
