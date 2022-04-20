using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    [SerializeField]
    private Deck _deck;

    [SerializeField]
    private Hand _hand;

    [SerializeField]
    private Transform _playerHand;

    public void Draw()
    {
        // Draw first card from deck's aspect list from deck to hand
        if (Input.GetMouseButtonDown(0))
            _deck.InitializeGame(_hand._cardsInHand, _playerHand);


    }

}
