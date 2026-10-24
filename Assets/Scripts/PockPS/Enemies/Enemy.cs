using UnityEngine;

public class Enemy : Fighter
{
    
    
    private bool TryChooseAction(BattleAction action)
    {
        if(energy >= action.cost)
        {
            currentTurnActions.Add(action);
            energy--;
            return true;
        }
        return false;
    }
}
