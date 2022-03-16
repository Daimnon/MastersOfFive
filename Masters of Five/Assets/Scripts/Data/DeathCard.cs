using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Death Card", menuName = "Card/Death")]
public class DeathCard : Card {

	public DeathCard()
	{
		PrimodialPower = PowerType.Death;
	}
}
