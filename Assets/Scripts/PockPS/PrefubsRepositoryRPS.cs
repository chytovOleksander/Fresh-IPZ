using System;
using System.Collections.Generic;
using UnityEngine;

public class PrefubsRepositoryRPS : MonoBehaviour
{
    [Header("Assign Prefabs Here")]
    [SerializeField] private BattleAction rockChosenActionPrefab;
    [SerializeField] private BattleAction rockAttackActionPrefab;
    [SerializeField] private BattleAction scissorsChosenActionPrefab;
    [SerializeField] private BattleAction scissorsAttackActionPrefab;
    [SerializeField] private BattleAction paperChosenActionPrefab;
    [SerializeField] private BattleAction paperAttackActionPrefab;

    public static PrefubsRepositoryRPS Instance;

    private Dictionary<Type, BattleAction> battleActionPrefubs;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        battleActionPrefubs = new Dictionary<Type, BattleAction>()
        {
            { typeof(Rock), rockChosenActionPrefab },
            { typeof(RockAttack), rockAttackActionPrefab },
            {typeof(Scissors), scissorsChosenActionPrefab },
            {typeof(ScissorsAttack), scissorsAttackActionPrefab },
            { typeof(Paper), paperChosenActionPrefab },
            { typeof(PaperAttack), paperAttackActionPrefab }
        };
    }

    public BattleAction GetPrefab<T>() where T : BattleAction
    {
        if (battleActionPrefubs.TryGetValue(typeof(T), out BattleAction prefab))
        {
            return prefab;
        }
        return null;
    }
}

