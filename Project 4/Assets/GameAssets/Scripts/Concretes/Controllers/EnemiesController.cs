using Project4.Concretes.Combats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.Controllers
{
    public class EnemiesController : MonoBehaviour
    {
        Health health;
        Damage damage;

        private void Awake()
        {
            health = GetComponent<Health>();
            damage = GetComponent<Damage>();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health health = collision.collider.GetComponent<Health>();
            if (health != null)
            {
                health.TakingHit(damage);
            }
        }
    }
}
