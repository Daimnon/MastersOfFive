using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Control Card", menuName = "Card/Control")]
public class ControlCard : Card
{
	public ControlCard()
    {
		PrimodialPower = PowerType.Control;
	}

	public void Action()
	{
		Debug.Log("Do Control Action");
	}

	public void SupremeAction()
	{
		Debug.Log("Do Control Supreme Action");
	}

	public void SecondaryAction()
	{
		Debug.Log("Do Control Secondary Action");
	}
}
