using UnityEngine;

public class Paper : BattleAction
{
    public RockPaperScissors rockPaperScissors = RockPaperScissors.Paper;
    public GameObject paperEffPrefub;
    public override void Execute()
    {
        GameObject paperEff = Instantiate(paperEffPrefub);
        PaperChosenEffect eff = paperEff.GetComponent<PaperChosenEffect>();

        owner.AddStatusEffect(eff);

        PaperAttack paper = Instantiate(PrefubsRepositoryRPS.Instance.GetPrefab<PaperAttack>()) as PaperAttack;
        paper.owner = owner;
        GameManager.Instance.allTurnActions.Add(paper);
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
