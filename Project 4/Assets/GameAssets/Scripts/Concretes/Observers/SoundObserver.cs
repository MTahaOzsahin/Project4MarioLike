using Project4.Concretes.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.Observers
{
    public class SoundObserver : MonoBehaviour
    {
        AudioSource audioSource;
        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }
        private void OnEnable()
        {
            PlayerController.OnPLayerDead += PlaySoundOneShot;
            EnemyMaceController.OnEnemyDead += PlaySoundOneShot;
        }


        void PlaySoundOneShot(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
