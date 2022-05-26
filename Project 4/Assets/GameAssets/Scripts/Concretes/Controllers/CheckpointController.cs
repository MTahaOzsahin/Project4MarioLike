using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.Controllers
{
    public class CheckpointController : MonoBehaviour
    {
        bool isPassed = false;

        public bool IsPassed => isPassed;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerController>() != null)
            {
                isPassed = true;
            }
        }
    }
}
