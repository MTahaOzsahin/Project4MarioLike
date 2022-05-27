using Project4.Concretes.Managers;
using Project4.Concretes.Uis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.Controllers
{
    public class EndController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                GameCanvas gameCanvas = FindObjectOfType<GameCanvas>();

                if (gameCanvas != null)
                {
                    gameCanvas.ShowGameOverPanel();
                }
            }
        }
    }
}
