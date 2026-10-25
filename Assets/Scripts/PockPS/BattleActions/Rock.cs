using UnityEngine;

public class Rock : BattleAction
{
    public RockPaperScissors rockPaperScissors = RockPaperScissors.Rock;
    public GameObject rockEffPrefub;
    public override void Execute()
    {
        GameObject rockeff = Instantiate(rockEffPrefub);
        RockChosenEffect eff = rockeff.GetComponent<RockChosenEffect>();
        
        owner.AddStatusEffect(eff);

        RockAttack rock = Instantiate(PrefubsRepositoryRPS.Instance.GetPrefab<RockAttack>()) as RockAttack;
        rock.owner = owner;
        GameManager.Instance.allTurnActions.Add(rock);
        GameManager.Instance.SortBySpeed(GameManager.Instance.allTurnActions);
        FinishAction();
    }
    private void Start()
    {
        speed = 1000;
    }
    public override void FinishAction()
    {
        actionFinished = true;
    }
    
}
