using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallEnemy : Enemy, IDamageable
{
    private const float DISTANCE_LIMIT = 0.8f;

    [SerializeField]private int _health;

    Transform playerPosition;

    private Vector3 _direction;
    [SerializeField]float followPlayerSpeed;

    [SerializeField] Slider sldHealthBar;
    
    void Start()
    {
        followPlayerSpeed = 2;
        _health = 20;    //!temporario!!
        playerPosition = GameManager.Instance.PlayerPosition;
        if (playerPosition == null)
        {
            Debug.LogError("Player reference not found.");
        }
        sldHealthBar.maxValue = _health;
    }


    void FixedUpdate()
    {
        if (playerPosition == null)
            return;
        
        Movement();
        
    }

    void Movement(){
        _direction = (playerPosition.position - transform.position).normalized;

        float distance = Vector3.Distance(playerPosition.position, transform.position);

        if(distance > DISTANCE_LIMIT)
            transform.position += _direction * followPlayerSpeed * Time.fixedDeltaTime;
    }

    void IDamageable.TakeDamage(int damageAmount)
    {
        Debug.Log(gameObject.name + " recebeu " + damageAmount.ToString() + " de dano!");
        _health -= damageAmount;
        UpdadeSliderHealthBar();
        if (_health <= 0)
        {
            ((IDamageable)this).Death();
        }
    }

    void IDamageable.Death()
    {
        Destroy(gameObject);
    }

    void UpdadeSliderHealthBar(){
        sldHealthBar.value = (_health >= 0) //IF ternário
        ? _health   //condição verdadeira   
        : 0;        //condição falsa
    }
}
