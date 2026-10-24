using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField]private int currentHealt = 3;
    [SerializeField]private int maxHealth = 3;
    [SerializeField]private string fighterName;

    public int energy = 0;

    public Action<int, Fighter> onDamageTaken;
    public Action<Fighter> onFatalDamage;
    public Action<Fighter> onDeath;
    public Action<BattleAction, Fighter> onActionAdded;
    
    public List<BattleAction> currentTurnActions = new();
    public List<BattleAction> battleActions = new();
    public List<StatusEffect> statusEffects = new();

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

    public int CurrentHealth
    {
        get { return currentHealt; }
        set { currentHealt = value; }
    }

    private void Start()
    {
        GameManager.Instance.onNewTurn += NewTurn;
        GameManager.Instance.fighters.Add(this);
        GameManager.Instance.onTurnStarted += TurnStart;
    }

    private void TurnStart()
    {
        GameManager.Instance.allTurnActions.AddRange(currentTurnActions);
    }

    private void NewTurn(int turn)
    {
        foreach (var action in currentTurnActions) if(action != null)action.Delete();
        currentTurnActions.Clear();
        energy = turn;
    }
    //TO do: 
    //  add button class to choose actions in battle. Test events using buttons, setup debug logs, extend action class to include
    //  its duration, animation, set up turn planning for both sides, set up placeholder visuals for fighters, extend enemy class to include
    //  animations.
}
