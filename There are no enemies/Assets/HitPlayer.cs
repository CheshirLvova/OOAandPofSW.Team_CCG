using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
namespace Platformer.Mechanics
{
    public class HitPlayer : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D collision)
        {
            int damage = this.GetComponent<Enemy>().damage;
            if (collision.gameObject.tag == "Player")
            {
                var playerHealth = collision.gameObject.GetComponent<Health>();
                playerHealth.TakeDamage(damage);
                var player = collision.gameObject.GetComponent<PlayerController>();
                player.Bounce(3);
            }
        }
    }
}
