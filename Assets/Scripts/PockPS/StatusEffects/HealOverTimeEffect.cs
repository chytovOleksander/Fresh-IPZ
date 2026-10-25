using System;
using UnityEngine;

public class HealOverTimeEffect : StatusEffect
{
    private int turnCounter = 0;
    protected override void Start()
    {
        base.Start();
        owner.onDamageTaken += (int n, Fighter owner, BattleAction a) => Perish();
        GameManager.Instance.onNewTurn += TryHeal;
    }

    private void TryHeal(int turn)
    {
        turnCounter++;
        if(turnCounter == 2)
        {
            if (owner.CurrentHealth < owner.MaxHealth)
            {
                owner.CurrentHealth++;
                turnCounter = 0;
            }
            else Perish();
            
        }
    }
}
