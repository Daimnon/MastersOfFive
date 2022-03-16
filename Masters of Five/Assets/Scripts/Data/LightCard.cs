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
}
