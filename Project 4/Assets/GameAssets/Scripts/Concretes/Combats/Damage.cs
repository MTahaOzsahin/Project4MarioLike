using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.Combats
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] int damage;

        public int DamageOfHit => damage;

        public void HittingTarget(Health health)
        {
            health.TakingHit(this);
        }
    }
}
