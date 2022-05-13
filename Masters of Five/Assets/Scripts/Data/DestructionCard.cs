using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Destruction Card", menuName = "Card/Destruction")]
public class DestructionCard : Card
{
	public DestructionCard()
	{
		PrimodialPower = PowerType.Destruction;
	}

	public void Action(EventHandler eventHandler)
	{
		// fix needed
		eventHandler.DrawCard();
	}

	public void SupremeAction()
	{
		Debug.Log("Do Destruction Supreme Action");
	}

	public void SecondaryAction()
	{
		Debug.Log("Do Destruction Secondary Action");
	}
}
