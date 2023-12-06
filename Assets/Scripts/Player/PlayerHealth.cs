using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private const int ENEMY_LAYER = 6;
    [SerializeField]private PlayerData playerData;
    public static Action<int> OnPlayerHurth;
    void IDamageable.Death()
    {
        throw new System.NotImplementedException();
    }

    void IDamageable.TakeDamage(int damageAmount)
    {
        int dif = playerData.Health - damageAmount;
        playerData.Health =  (dif > 0)
        ? dif
        : 0;

        if (playerData.Health <= 0)
        {
                ((IDamageable)this).Death();
        }
        OnPlayerHurth?.Invoke(playerData.Health);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == ENEMY_LAYER)
        {
            int damage = other.gameObject.GetComponent<Enemy>().AttackDamage;
            Debug.Log($"O jogador perdeu {damage} de vida!");
            ((IDamageable)this).TakeDamage(damage);
        }
    }
}
