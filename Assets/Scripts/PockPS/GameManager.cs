using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Fighter Player;
    public List<Fighter> fighters = new();

    public int currentTurn = 0;
    public List<BattleAction> allTurnActions = new();

    public Action<int> onNewTurn;
    public Action onTurnStarted;
    public Action<Fighter> onFighterDeath;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        StartGame();
    }
    private void StartGame()
    {
        StartCoroutine(GameStart());
    }
    private IEnumerator GameStart()
    {
        yield return null;
        NewTurn();
    }


    public void NewTurn()
    {
        currentTurn++;
        foreach(var ba in allTurnActions)
        {
            ba.Delete();
        }
        allTurnActions.Clear();
        onNewTurn?.Invoke(currentTurn);
    }
    public void StartTurn()
    {
         onTurnStarted?.Invoke();
        Debug.Log(allTurnActions.Count);
        StartCoroutine(Fight());
    }
    private IEnumerator Fight()
    {
        Debug.Log("Fight started:");
        yield return null;
        SortBySpeed(allTurnActions);
        for(int i = 0; i < allTurnActions.Count; i++)
        {
            allTurnActions[i].Execute();
            Debug.Log("From " + ToString() + " Executing " +  allTurnActions[i].ToString());
            yield return new WaitUntil(() => allTurnActions[i].actionFinished == true);
        }
        yield return null;
        Debug.Log("Fight ended");
        NewTurn();
    }
    public void SortBySpeed(List<BattleAction> list)
    {
        list.Sort((a, b) => b.speed.CompareTo(a.speed));
    }
}
