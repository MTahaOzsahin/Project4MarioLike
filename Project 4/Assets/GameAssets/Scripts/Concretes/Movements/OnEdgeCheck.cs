using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.Movements
{
    [RequireComponent(typeof(Collider2D))]
    public class OnEdgeCheck : MonoBehaviour
    {
        Collider2D sawCollider2D;
        [SerializeField] LayerMask layerMask;
        [SerializeField] float distance;
        float direction;

        private void Awake()
        {
            sawCollider2D = GetComponent<Collider2D>();
            direction = 1f;
        }

        public bool IsReachedEdge()
        {
            float x = GetForwardXDirection();
            float y = sawCollider2D.bounds.min.y;

            Vector2 origin = new Vector2(x, y);

            RaycastHit2D hit2D = Physics2D.Raycast(origin, Vector2.down, distance, layerMask);
            Debug.DrawRay(origin, Vector2.down * distance, Color.red);

            if (hit2D.collider != null) return false;
            SwitchControlDirection();
            return true;
        }
        float GetForwardXDirection()
        {
            return direction == -1 ? sawCollider2D.bounds.center.x - 0.1f : sawCollider2D.bounds.center.x + 0.1f; //Gittiði taraftaki sýnýr colliderin bir týk ötesi
        }
        void SwitchControlDirection()
        {
            direction *= -1;
        }
    }
}
