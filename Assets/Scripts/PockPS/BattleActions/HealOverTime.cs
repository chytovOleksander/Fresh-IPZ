using UnityEngine;

public class HealOverTime : BattleAction
{
    public GameObject healEffPrefub;
    public override void Execute()
    {
        GameObject healEff = Instantiate(healEffPrefub);
        HealOverTimeEffect eff = healEff.GetComponent<HealOverTimeEffect>();
        owner.AddStatusEffect(eff);
        FinishAction();
    }

    public override void FinishAction()
    {
        actionFinished = true;
    }    
}
