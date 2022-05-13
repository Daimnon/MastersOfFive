using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Light Card", menuName = "Card/Light")]
public class LightCard : Card
{
	public LightCard()
	{
		PrimodialPower = PowerType.Light;
	}

	public void Action(EventHandler eventHandler)
	{
		// fix needed
		eventHandler.DrawCard();
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
