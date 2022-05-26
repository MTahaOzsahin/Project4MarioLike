using Project4.Concretes.Combats;
using Project4.Concretes.ExtensionMethods;
using Project4.Concretes.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.Controllers
{
    public class EnemyMaceController : MonoBehaviour
    {
        [SerializeField] AudioClip deadClip;
        
        Mover mover;
        OnEdgeCheck edgeCheck;

        float direction;


        Health health;
        Damage damage;


        public static event System.Action<AudioClip> OnEnemyDead;


        private void Awake()
        {
            health = GetComponent<Health>();
            damage = GetComponent<Damage>();
            direction = 1f;
            mover = GetComponent<Mover>();
            edgeCheck = GetComponent<OnEdgeCheck>();
        }
        private void OnEnable()
        {
            health.OnDead += DeadAction;
            health.OnDead += () => OnEnemyDead(deadClip);
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

        void DeadAction()
        {
            Destroy(this.gameObject);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health health = collision.ObjectHasHealth();
            if (health != null && collision.WasHitRightOrLeftSide())
            {
                health.TakingHit(damage);
            }
        }
    }
}
