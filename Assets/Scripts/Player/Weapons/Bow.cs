using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bow : MonoBehaviour, IWeapon
{
    [SerializeField] WeaponBase _base;
    List<Enemy> enemyList;
    bool canAttack = true;


    public void AutoAttack()
    {

        if (canAttack)
        {
            StartCoroutine(Attack());
        }


    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.forward, _base.AttackRange);
#endif
    }

    public void CheckEnemy()
    {


        Collider2D[] inimigosDetectados = Physics2D.OverlapCircleAll(transform.position, _base.AttackRange, _base.EnemyLayer);
        enemyList = new List<Enemy>();


        foreach (Collider2D inimigo in inimigosDetectados)
        {

            if (!enemyList.Contains(inimigo.GetComponent<Enemy>()))
            {
                enemyList.Add(inimigo.GetComponent<Enemy>());
                Debug.Log("Encontrei o inimigo");
            }
        }
    }

    public void LevelUp()
    {
        throw new System.NotImplementedException();
    }


    IEnumerator Attack()
    {



        if (canAttack)
        {

            CheckEnemy();
            canAttack = false;

            if (enemyList.Count > 0)
            {
                enemyList[0].GetComponent<IDamageable>().TakeDamage(_base.Damage);


            }
        }

        yield return new WaitForSeconds(_base.Cd);

        canAttack = true;





    }
}
