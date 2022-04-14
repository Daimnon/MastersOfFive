using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// Phases example:
/// 
///     p1 turn:
/// draw phase ----- // p1 draw card
/// action phase --- // p1 plays light
/// negation phase - // p2 choose to skip negation
/// reaction phase - // p1 draw one extra card (the card is control)
/// end phase ------ // pass turn
///
///     p2 turn:
/// draw phase ----- // p2 draw card
/// action phase --- // p2 plays destruction
/// negation phase 1 // p1 try to negate by moving 1 control & 1 destruction/ another control to the tomb
/// negation phase 2 // p2 try to negate p1 negation but don't have 2 control cards
/// reaction phase - // p1 negates & p2 send own destruction to tomb
/// end phase ------ // pass turn
/// 
/// </summary>

public class PhaseHandler : MonoBehaviour
{
    private void DrawPhase(Player player)
    {
        // Make top card of deck be removed from deck & added to player hand
    }

    private void ActionPhase(Player player)
    {
        // Make the player able to do place a card from their hand
        // Make sure the action is optional and do not force the player to do it
    }

    private void NegationPhase(Player player)
    {
        // the turn should go to the opponent, while its their turn
        // they can skip this phase or negate an aspect (with the right conditions cleared)
        // the turn then return to the player to continue
    }

    private void ReactionPhase(Player player)
    {
        // resolve all of the things that should've occur,
        // check if action resolved succesfully, if so incloud it, if not break it
        
    }

    private void EndPhase(Player player)
    {
        // activate turn handler
        /* - !! -  DO NOT MAKE TURN SWIITCH FROM HERE  - !! - */
    }
}
