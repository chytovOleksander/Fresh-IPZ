using System;
using UnityEngine;

public abstract class BattleAction : MonoBehaviour, IComparable
{
    public int speed = 1;
    public int cost = 1;
    public Fighter owner;
    public bool actionFinished = false;

    public int CompareTo(object obj)
    {
        return speed.CompareTo(obj as BattleAction);
    }

    public abstract void Execute();
    public void Delete()
    {
        Debug.Log("Destroying " + ToString());
        Destroy(gameObject);
    }
    public abstract void FinishAction();
}
