using UnityEngine;

public class Player : Fighter
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.Player = this;
    }
}
