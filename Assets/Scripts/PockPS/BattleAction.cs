using System;
using UnityEngine;

public abstract class BattleAction : MonoBehaviour, IComparable
{
    public int speed = 1;
    public int cost = 1;

    public int CompareTo(object obj)
    {
        return speed.CompareTo(obj as BattleAction);
    }

    public abstract void Execute();
    public void Delete()
    {
        Destroy(gameObject);
    }
}
