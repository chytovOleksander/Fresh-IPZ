using System;
using UnityEngine;

public abstract class BattleAction : MonoBehaviour, IComparable
{
    public int speed = 1;
    public int cost = 1;
    public float animDuration = 1;
    public Fighter owner;
    
    public bool actionFinished = false;
    public GameObject actionVisuals;

    protected Animator animator;
    public int CompareTo(object obj)
    {
        return speed.CompareTo(obj as BattleAction);
    }

    public abstract void Execute();
    public void Delete()
    {
        Debug.Log("Destroying " + ToString());
        Destroy(gameObject);
    }
    public abstract void FinishAction();

    /** Action ideas: 1. Buff for r\p\s to not be blocked by themselves
     * 2. Procrastination: Erase next enemy action and bring double of it next turn
     * 3. Box: For 3 next turn collects r or p or s used and when done releases al of them at once
     * 4. Quick strike: Deals 1 damage if not blocked by scissors
     * 5. Block: blocks r/p/s but does not attack
     * 6. Counter: Gives buff having to do with succesful blocking
     * 7. While true: Copies all of actions this turn and adds them infinetely until someone dies or break
     * 8. persist: cant die this turn and does something to make it harder to cast this
     * 9. Calm down: Remove all buffs and debuffs and recovers hp based on the amount
     * 10. Open wound: s strike deals 1 damage and applies bleed(target loses hp every 2 turn until succeful hit)
     * 11. Death note: Very high cost, deals 777 damage
     * 12. Stun: r strike, inflicts stun: can't strike
     * 13. Blind: Can't draw cards
     */
    
}
