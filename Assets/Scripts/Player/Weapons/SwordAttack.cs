using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SwordAttack : MonoBehaviour
{

    private const string TRIGGER_ATTACK_ANIMATION = "tgrAttack";
    private Animator animator;

    private int _attackDamage;

    //variaveis de controle
    [SerializeField]float attackCooldown;
    [SerializeField]float overTime;

    void Start()
    {
        _attackDamage = 2;
        attackCooldown = 2.0f;
        overTime = attackCooldown;
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        overTime -= Time.fixedDeltaTime;

        if (overTime <= 0.0f)
        {
            overTime = attackCooldown;
            AttackAnimation();
        }
    }

    private void AttackAnimation(){
        animator.SetTrigger(TRIGGER_ATTACK_ANIMATION);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<IDamageable>()?.TakeDamage(_attackDamage);
        Debug.Log("ACERTOU: " + other.name);
    }

}
