using Project4.Concretes.Combats;
using Project4.Concretes.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.ExtensionMethods
{
    public static class ColliderExtensionMethod
    {
        public static bool WasHitRightOrLeftSide(this Collision2D collision)
        {
            return collision.GetContact(0).normal.x > 0.6f || collision.GetContact(0).normal.x < -0.6f;
        }
        public static bool WasHitBottomSide(this Collision2D collision)
        {
            return collision.GetContact(0).normal.y < -0.6f;
        }
        public static bool WasHitTopSide(this Collision2D collision)
        {
            return collision.GetContact(0).normal.y > 0.6f;
        }
        public static bool HasHitPlayer(this Collision2D collision)
        {
            return collision.collider.GetComponent<PlayerController>() != null;
        }
        public static bool HasHitEnemy(this Collision2D collision)
        {
            return collision.collider.GetComponent<EnemyMaceController>() != null || collision.collider.GetComponent<EnemySawController>() != null;
        }
        public static Health ObjectHasHealth(this Collision2D collision)
        {
            Health health = collision.collider.GetComponent<Health>();
            if (health != null)
            {
                return health;
            }
            return null;
        }
    }
}
