using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goblin : Enemy, IDamageable
{
    private const float DISTANCE_LIMIT = 0.8f;
    [SerializeField] BaseEnemy baseEnemy;

    Transform playerPosition;

    private Vector3 _direction;

    [SerializeField] Slider sldHealthBar;
    
    void Start()
    {
        base.Health = baseEnemy.Health;
        base.AttackDamage = baseEnemy.AttackDamage;    
        base.Speed = baseEnemy.Speed;

        playerPosition = GameManager.Instance.PlayerPosition;

        if (playerPosition == null)
            Debug.LogError("Player reference not found.");
            
        sldHealthBar.maxValue = Health;
    }

    void FixedUpdate()
    {
        if (playerPosition == null)
            return;
        
        Movement();
        
    }


    protected override void Attack(){
        base.Attack();
    }

    protected override void Movement(){
        base.Movement();

        _direction = (playerPosition.position - transform.position).normalized;

        float distance = Vector3.Distance(playerPosition.position, transform.position);

        if(distance > DISTANCE_LIMIT)
            transform.position += _direction * base.Speed * Time.fixedDeltaTime;
        else
            Attack();
    }

    void IDamageable.TakeDamage(int damageAmount)
    {
        Debug.Log(gameObject.name + " recebeu " + damageAmount.ToString() + " de dano!");
        Health -= damageAmount;
        UpdadeSliderHealthBar();
        if (Health <= 0)
        {
            ((IDamageable)this).Death();
        }
    }

    void IDamageable.Death()
    {
        Debug.Log("Inimigo "+this.gameObject.name + " morreu!");
        Destroy(gameObject);
    }

    void UpdadeSliderHealthBar(){
        sldHealthBar.value = (Health >= 0) //IF ternário
        ? Health   //condição verdadeira   
        : 0;        //condição falsa
    }
}
