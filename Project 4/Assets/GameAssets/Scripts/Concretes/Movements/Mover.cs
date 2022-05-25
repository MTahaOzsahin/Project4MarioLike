using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.Movements
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] float moveSpeed;

        public void Movement(float horizontal)
        {
            transform.Translate(Vector2.right * horizontal * Time.deltaTime * moveSpeed);
            if (horizontal != 0)
            {
                transform.localScale = new Vector2(Mathf.Sign(horizontal), 1f); //Karakterin sa�a sola d�nmesini sa�l�yor.
            }
        }
    }
}

