using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.Movements
{
    public class OnGroundCheck : MonoBehaviour
    {
        [SerializeField] bool isGorunded = false;
        [SerializeField] Transform[] transforms;
        [SerializeField] LayerMask layerMask;
        [SerializeField] float distance;

        public bool IsGrounded => isGorunded;

        private void Update()
        {
            CheckingOnGround();
        }
        void CheckOnGround(Transform footTransfrom)
        {
            RaycastHit2D hit = Physics2D.Raycast(footTransfrom.position, footTransfrom.forward, distance, layerMask); 
            Debug.DrawRay(footTransfrom.position, footTransfrom.forward * distance, Color.red); //dont forget change foots x-rotations to 90

            if (hit.collider != null)
            {
                isGorunded = true;
            }
            else
            {
                isGorunded = false;
            }
        }

        void CheckingOnGround()
        {
            foreach (Transform footTransfrom in transforms)
            {
                CheckOnGround(footTransfrom);

                if (isGorunded) break;
                
            }
        }
    }
}
