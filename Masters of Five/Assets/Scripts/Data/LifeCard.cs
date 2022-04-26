using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Life Card", menuName = "Card/Life")]
public class LifeCard : Card
{
	public LifeCard()
	{
		PrimodialPower = PowerType.Life;
	}

	public void Action()
	{
		Debug.Log("Do Life Action");
	}

	public void SupremeAction()
	{
		Debug.Log("Do Life Supreme Action");
	}

	public void SecondaryAction()
	{
		Debug.Log("Do Life Secondary Action");
	}
}
