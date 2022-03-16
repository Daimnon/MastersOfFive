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
}
