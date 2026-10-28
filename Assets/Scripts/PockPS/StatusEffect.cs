using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class StatusEffect : MonoBehaviour
{
    public int duration;
    public Fighter owner;
    public string effectName;
    public string effectDescription;
    public Image effectImage;
    public EffectPositivity effectPositivity;

    public enum EffectPositivity
    {
        positive,
        negative,
        neutral
    }
   protected virtual void Start()
    {
        GameManager.Instance.onNewTurn += SubtructDuration;
        effectImage = GetComponent<Image>();
    }

    public virtual void SubtructDuration(int obj)
    {
        duration--;
        if(duration <= 0)
        {
            Perish();
        }
    }

    public virtual void Perish()
    {
        if (this == null) return;
        owner.statusEffects.Remove(this);
        UIManager.Instance.RemoveStatusEffect(this, owner);
        Debug.Log(ToString() + " is Perishing from " + owner.ToString());
        GameManager.Instance.onNewTurn -= SubtructDuration;
        Destroy(gameObject);
    }
 
}
