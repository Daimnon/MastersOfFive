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
}
