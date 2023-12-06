using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy: MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int attackDamage;
    [SerializeField] private int skillkDamage;
    [SerializeField] private float speed;
    [SerializeField] private float attackRange;
    [SerializeField] private float skillkRange;

    protected int Health { get => health; set => health = value; }
    public int AttackDamage { get => attackDamage; set => attackDamage = value; }
    public int SkillkDamage { get => skillkDamage; set => skillkDamage = value; }
    protected float Speed { get => speed; set => speed = value; }
    protected float AttackRange { get => attackRange; set => attackRange = value; }
    protected float SkillkRange { get => skillkRange; set => skillkRange = value; }

    protected virtual void Attack(){}
    protected virtual void Skill(){}
    protected virtual void Movement(){}
}
