using UnityEngine;

public class Rock : BattleAction
{
    public RockPaperScissors rockPaperScissors = RockPaperScissors.Rock;
    public GameObject rockEffPrefub;
    public override void Execute()
    {
        RockChosenEffect rockEff = rockEffPrefub.GetComponent<RockChosenEffect>();
        owner.statusEffects.Add( rockEff );
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
