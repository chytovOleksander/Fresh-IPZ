using UnityEngine;

public class ScissorsAttack : BattleAction
{
    public override void Execute()
    {
        Fighter target = null;
        foreach (var fighter in GameManager.Instance.fighters)
        {
            if (fighter != owner) target = fighter;
        }
        bool hasBlock()
        {
            foreach (var eff in target.statusEffects)
            {
                if (eff is RockChosenEffect || eff is ScissorsChosenEffect)
                {
                    Debug.Log("Keyword (is) correctly worked with: attack is blocked");
                    return true;
                }
            }
            return false;
        }
        if (!hasBlock())
        {
            target.TakeDamage(1);
        }        
        FinishAction();
    }

    public override void FinishAction()
    {
        bool actionFinished = true;
    }

    
}
