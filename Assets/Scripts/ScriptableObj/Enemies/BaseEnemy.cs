using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BaseEnemy", menuName = "Enemy/Create new enemy")]
public class BaseEnemy : ScriptableObject
{
    [SerializeField] int _health;
    [SerializeField] int _attackDamage;
    [SerializeField] int _skillkDamage;
    [SerializeField] float _speed;
    [SerializeField] float _attackRange;
    [SerializeField] float _skillkRange;

    public int Health { get => _health; set => _health = value; }
    public int AttackDamage { get => _attackDamage; set => _attackDamage = value; }
    public int SkillkDamage { get => _skillkDamage; set => _skillkDamage = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public float AttackRange { get => _attackRange; set => _attackRange = value; }
    public float SkillkRange { get => _skillkRange; set => _skillkRange = value; }


}


