using UnityEngine;

public class RockAttack : BattleAction
{
    
    public override void Execute()
    {
        Fighter target = null;
        foreach(var fighter in GameManager.Instance.fighters)
        {
            if(fighter != owner) target = fighter;
        }
        bool hasRock()
        {
            foreach(var eff in target.statusEffects)
            {
                if(eff is RockChosenEffect)
                {
                    Debug.Log("Keyword is worked with: effect is Script");
                    return true;
                }
            }
            return false;
        }
        if (!hasRock())
        {
            target.TakeDamage(1);
        }
        FinishAction();
    }

    public override void FinishAction()
    {
        actionFinished = true;
    }
}
