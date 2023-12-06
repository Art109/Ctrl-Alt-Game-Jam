using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Player/Weapon/Create new weapon")]
public class WeaponBase : ScriptableObject
{
    [SerializeField] float attackRange;
    [SerializeField] int damage;
    [SerializeField] int lv;
    [SerializeField] float cd;
    [SerializeField] LayerMask enemyLayer;

    public float AttackRange 
    {
        get { return attackRange; }
        set { attackRange = value; }

    }

    public int Damage
    {
        get { return damage; }
        set { damage = value; }

    }

    public int Lv
    {
        get { return lv; }
        set { lv = value; }
         
    }

    public float Cd
    {
        get { return cd; }
        set { cd = value; }

    }

    public LayerMask EnemyLayer
    {
        get { return enemyLayer; }

    }
}




