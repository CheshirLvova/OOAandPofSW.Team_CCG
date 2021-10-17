using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatScript : MonoBehaviour
{
    public Animator aimator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float attackRate = 2f;
    public int damage=10;
    private float nextAttackTime = 0f;
    public LayerMask enemyLayers;
    private List<string> attacks= new List<string>{"Attack1","Attack2","Attack3"};
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown("mouse 0"))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    void Attack()
    {
        aimator.SetTrigger(attacks[Random.Range(0, attacks.Count)]);
        Collider2D[] hitEnemies= Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().takeDamage(damage);
        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
}
}
