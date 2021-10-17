using System;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Represebts the current vital statistics of some game entity.
    /// </summary>
    public class Health : MonoBehaviour
    {

        public int maxHP = 100;
        public bool IsAlive => currentHP > 0;
        int currentHP;
        public Animator aimator;

        public void Increment()
        {
            currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);
        }
        public void FullHeal()
        {
            currentHP = maxHP;
        }
        public int getHealth()
        {
            return currentHP;
        }
        public void TakeDamage(int damage=1)
        {
            aimator.SetTrigger("Hurt");
            currentHP = Mathf.Clamp(currentHP - damage, 0, maxHP);
            Debug.Log(currentHP);
            if (currentHP <= 0)
            {
                var ev = Schedule<HealthIsZero>();
                ev.health = this;
            }
        }

        public void Die()
        {
            currentHP=0;
        }

        void Awake()
        {
            currentHP = maxHP;
        }
    }
}
