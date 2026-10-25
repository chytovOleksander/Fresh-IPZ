using UnityEngine;
using UnityEngine.Events;

public class Enemy : Fighter
{
    protected override void Start()
    {
        base.Start();
        GameManager.Instance.onNewTurn += (int num) => AddCurrentTurnAction(battleActions[Random.Range(0, battleActions.Count)]);
    }

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
