using Project4.Concretes.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.Observers
{
    public class SoundObserver : MonoBehaviour
    {
        public static SoundObserver Instance { get; private set; }



        AudioSource audioSource;
        private void Awake()
        {
            SingeltonThisGameObject();
            audioSource = GetComponent<AudioSource>();
        }
        void SingeltonThisGameObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        private void OnEnable()
        {
            PlayerController.OnPLayerDead += PlaySoundOneShot;
            EnemyMaceController.OnEnemyDead += PlaySoundOneShot;
            ScoreController.OnScoreSoundClip += PlaySoundOneShot;
        }


        void PlaySoundOneShot(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
