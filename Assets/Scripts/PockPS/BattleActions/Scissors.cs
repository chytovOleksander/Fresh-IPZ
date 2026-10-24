using UnityEngine;

public class Scissors : BattleAction
{
    public RockPaperScissors rockPaperScissors = RockPaperScissors.Scissors;
    public GameObject scissorsEffPrefub;
    public override void Execute()
    {
        ScissorsChosenEffect scissorsEff = scissorsEffPrefub.GetComponent<ScissorsChosenEffect>();
        owner.statusEffects.Add(scissorsEff);
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
