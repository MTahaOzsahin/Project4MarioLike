using Project4.Concretes.Combats;
using Project4.Concretes.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.Controllers
{
    public class EnemySawController : MonoBehaviour
    {
        Mover mover;
        OnEdgeCheck edgeCheck;

        float direction;


        Health health;
        Damage damage;

        private void Awake()
        {
            health = GetComponent<Health>();
            damage = GetComponent<Damage>();
            direction = 1f;
            mover = GetComponent<Mover>();
            edgeCheck = GetComponent<OnEdgeCheck>();
        }
        private void FixedUpdate()
        {
            Movement(direction);
            SwitchEdge();
        }
        
        void SwitchEdge()
        {
            if (edgeCheck.IsReachedEdge())
            {
                direction *= -1;
            }
        }
        void Movement(float direction)
        {
            mover.Movement(direction);
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
