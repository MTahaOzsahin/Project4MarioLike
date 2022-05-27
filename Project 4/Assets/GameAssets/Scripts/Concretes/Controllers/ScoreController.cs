using Project4.Concretes.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.Controllers
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] AudioClip scoreClip;
        int score = 1;


        public static event System.Action<AudioClip> OnScoreSoundClip;

        private void Awake()
        {
            
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            
            if (player != null)
            {
                GameManager.Instance.IncreaseScore(score);
                OnScoreSoundClip.Invoke(scoreClip);
                Destroy(this.gameObject);
            }
        }
    }
}
