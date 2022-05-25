using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Project4.Concretes.Movements
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jump : MonoBehaviour
    {
        Rigidbody2D playerRigidbody2D;
        [SerializeField] float jumpForce;

        private void Awake()
        {
            playerRigidbody2D = GetComponent<Rigidbody2D>();
        }
        public void JumpAction()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRigidbody2D.velocity = Vector2.zero;
                playerRigidbody2D.AddForce(Vector2.up * jumpForce);
            }
        }
    }

    

}