using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Light Card", menuName = "Card/Light")]
public class LightCard : Card
{
	[SerializeField] private Deck _deck;
	[SerializeField] private Hand _hand;

	public LightCard()
	{
		PrimodialPower = PowerType.Light;
	}

	public void Action(List<Card> cardsInHand, Transform hand)
	{
		_deck.DrawCard(cardsInHand, hand);
	}

	public void SupremeAction()
	{
		Debug.Log("Do Light Supreme Action");
	}

	public void SecondaryAction()
	{
		Debug.Log("Do Light Secondary Action");
	}
}
