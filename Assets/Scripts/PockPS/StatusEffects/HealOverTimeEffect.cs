using System;
using UnityEngine;

public class HealOverTimeEffect : StatusEffect
{
    private int turnCounter = 0;
    protected override void Start()
    {
        base.Start();
        owner.onDamageTaken += SubPerish;
        GameManager.Instance.onNewTurn += TryHeal;
    }

    void SubPerish(int n, Fighter owner, BattleAction a)
    {
        Perish();
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
    private void OnDestroy()
    {
        GameManager.Instance.onNewTurn -= TryHeal;
        owner.onDamageTaken -= SubPerish;
    }
}
