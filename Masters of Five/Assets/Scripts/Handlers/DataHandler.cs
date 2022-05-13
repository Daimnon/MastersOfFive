using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    [Header("Data Scripts")]
    public Deck DeckData; 
    public Hand HandData; 
    public Battlefield BattlefieldData; 
    public Tomb TombData;

    public bool IsSacrificing = false;
}
