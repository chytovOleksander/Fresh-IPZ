using UnityEngine;

public class Scissors : BattleAction
{
    public RockPaperScissors rockPaperScissors = RockPaperScissors.Scissors;
    public GameObject scissorsEffPrefub;
    public override void Execute()
    {
        ScissorsChosenEffect scissorsEff = Instantiate(scissorsEffPrefub).GetComponent<ScissorsChosenEffect>();
        owner.AddStatusEffect(scissorsEff);

        ScissorsAttack scissors = Instantiate(PrefubsRepositoryRPS.Instance.GetPrefab<ScissorsAttack>()) as ScissorsAttack;
        scissors.owner = owner;
        GameManager.Instance.allTurnActions.Add(scissors);
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
