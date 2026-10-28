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

    public Action<int, Fighter, BattleAction> onDamageTaken;
    public Action<Fighter> onFatalDamage;
    public Action<Fighter> onDeath;
    public Action<BattleAction, Fighter> onActionAdded;
    
    public List<BattleAction> currentTurnActions = new();
    public List<BattleAction> battleActions = new();
    public List<StatusEffect> statusEffects = new();

    public void AddCurrentTurnAction(BattleAction bAction)
    { 
        bAction.owner = this;
        currentTurnActions.Add(Instantiate(bAction));
        Debug.Log(this + " Added currentTurnAction " + bAction.name);
        foreach (var action in currentTurnActions)
        {
            Debug.Log(action.ToString() + " Action" );
        }
        onActionAdded?.Invoke(bAction, this);
    }
    public virtual void TakeDamage(int damage, BattleAction source = null)
    {
        onDamageTaken?.Invoke(damage, this, source);
        currentHealt -= damage;
        if(currentHealt <= 0)
        {
            onFatalDamage?.Invoke(this);
            if(currentHealt <= 0)
            {
                onDeath?.Invoke(this);
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
        set { currentHealt = Math.Abs(value); }
    }
    public int MaxHealth
    {
        get { return maxHealth; }
    }
    protected virtual void Start()
    {
        GameManager.Instance.onNewTurn += NewTurn;
        GameManager.Instance.fighters.Add(this);
        GameManager.Instance.onTurnStarted += TurnStart;

        //for(int i = 0; i<battleActions.Count; i++)
        //{
        //    BattleAction obj = Instantiate(battleActions[i]);
        //    obj.owner = this;
        //}
    }

    private void TurnStart()
    {
        Debug.Log(currentTurnActions.Count);
        GameManager.Instance.allTurnActions.AddRange(currentTurnActions);
        Debug.Log(this.ToString() + "received event onTurnStarted");

    }

    private void NewTurn(int turn)
    {
        foreach (var action in currentTurnActions) if(action != null)action.Delete();
        currentTurnActions.Clear();
        energy += 5;
    }

    public virtual void AddStatusEffect(StatusEffect eff)
    {
        statusEffects.Add(eff);
        UIManager.Instance.AddStatusEffect(eff, this);
        eff.owner = this;
        Debug.Log(eff.ToString() + "is applied to" + ToString() + ". It's owner is:" + eff.owner);
    }
    //TO do: 
    //  set up turn planning for both sides,
    //   set up placeholder visuals for fighters, extend enemy class to include animations.
    // 
    // think of the gameplay loop. Develop ui, action cancelling, action disabling. :<
}
