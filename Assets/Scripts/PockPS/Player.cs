using UnityEngine;

public class Player : Fighter
{    
    protected override void Start()
    {
        base.Start();
        GameManager.Instance.Player = this;
    }
}
