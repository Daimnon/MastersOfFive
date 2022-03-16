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
}
