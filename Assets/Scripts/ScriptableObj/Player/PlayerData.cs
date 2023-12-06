using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "Player/Create new PlayerData", order = 0)]
public class PlayerData : ScriptableObject
{
    private const int MAX_HEALTH = 30;
    [SerializeField]private int _health;

    public int Health { get => _health; set => _health = value; }
    public static int MaxHealth { get => MAX_HEALTH; }

    public void SetToInitialState(){
        Health = MAX_HEALTH;
    }
}
