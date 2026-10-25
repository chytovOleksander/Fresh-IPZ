using System;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    private BattleAction linkedAction;
    public int playerBattleActionsId;//id of action linked to the button in player battleActions list
    
    private Button button;    
    void Start()
    {
        button = GetComponent<Button>();
        Debug.Log(GameManager.Instance.Player.ToString());
        Debug.Log(GameManager.Instance.Player.battleActions[playerBattleActionsId].ToString());

        linkedAction = GameManager.Instance.Player.battleActions[playerBattleActionsId];
        
        button.onClick.AddListener(ActionChosen);
    }

    protected virtual void ActionChosen()
    {
        Fighter player = GameManager.Instance.Player;
        if(player.energy >= linkedAction.cost)
        {
            player.energy -= linkedAction.cost;
            player.AddCurrentTurnAction(linkedAction);
            Debug.Log(this + " Added currentTurnAction " + linkedAction);
        }
        else
        {
            Debug.Log("Not enough energy");
        }
    }   
}
