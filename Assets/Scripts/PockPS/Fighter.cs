using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField]private int currentHealt = 3;
    [SerializeField]private int maxHealth = 3;
    [SerializeField]private string fighterName;

    public Action<int, Fighter> onDamageTaken;
    public Action<Fighter> onFatalDamage;
    public Action<Fighter> onDeath;
    public Action<BattleAction, Fighter> onActionAdded;
    
    private List<BattleAction> currentTurnActions = new();
    private List<BattleAction> battleActions = new();

    public void AddCurrentTurnAction(BattleAction bAction)
    {
        currentTurnActions.Add(bAction);
        onActionAdded.Invoke(bAction, this);
        //currentTurnActions.Sort();
    }
    public virtual void TakeDamage(int damage)
    {
        onDamageTaken.Invoke(damage, this);
        currentHealt -= damage;
        if(currentHealt <= 0)
        {
            onFatalDamage.Invoke(this);
            if(currentHealt <= 0)
            {
                onDeath.Invoke(this);
            }
        }
    }
    
    public void TurnEnd()
    {
        foreach(var action in currentTurnActions)
        {
            action.Delete();
        }
        currentTurnActions.Clear();
    }

    //TO do: Add player and enemy classes inheriting Fighter class, add a game manager singleton with turns mechanic and game handling
    // Add 3 basic rock paper scissors actions, add button class to choose actions in battle, add status effect class
}
