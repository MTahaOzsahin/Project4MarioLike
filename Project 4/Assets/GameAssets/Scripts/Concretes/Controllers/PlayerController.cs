using Project4.Abstracts.Inputs;
using Project4.Concretes.Combats;
using Project4.Concretes.Inputs;
using Project4.Concretes.Movements;
using Project4.Concretes.ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project4.Concretes.Uis;

namespace Project4.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] AudioClip deadClip;
        [SerializeField] AudioClip damageClip;
        [SerializeField] AudioClip jumpClip;


        Mover mover;
        IPlayerInputs pcInputs;
        AnimationController animationController;
        Jump jump;
        OnGroundCheck onGroundCheck;
        Health health;
        Damage damage;
        AudioSource audioSource;
        

        float horizontal;
        float vertical;


        public static event System.Action<AudioClip> OnPLayerDead;
        
        private void Awake()
        {
            mover = GetComponent<Mover>();
            jump = GetComponent<Jump>();
            onGroundCheck = GetComponent<OnGroundCheck>();
            pcInputs = new PcInputs();
            animationController = GetComponent<AnimationController>();
            health = GetComponent<Health>();
            damage = GetComponent<Damage>();
            audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            GameCanvas gameCanvas = FindObjectOfType<GameCanvas>();

            if (gameCanvas != null)
            {
                health.OnDead += gameCanvas.ShowGameOverPanel;
                DisplayHealth displayHealth = gameCanvas.GetComponentInChildren<DisplayHealth>();
                health.OnHealthChanged += displayHealth.WriteHealth;
            }
            health.OnDead += () => OnPLayerDead(deadClip);
            health.OnHealthChanged += PlaySoundOnHit;
            
        }

        
        private void Update()
        {
            GetAxis();
            PlayerJumpControl();
        }
        private void FixedUpdate()
        {
            PlayerMovement();
            PlayerRunningAnim();
        }

        void GetAxis()
        {
            horizontal = pcInputs.Horizontal;
            vertical = pcInputs.Vertical;
        }
        void PlayerMovement()
        {
            mover.Movement(horizontal);
        }
        void PlayerRunningAnim()
        {
            animationController.RunningAnim(horizontal);
        }
        void PlayerJumpControl()
        {
            bool isJumpActionOn = false;
            if (onGroundCheck.IsGrounded && Input.GetButtonDown("Jump"))
            {
                isJumpActionOn = true;
                audioSource.PlayOneShot(jumpClip);
                jump.JumpAction();
            }
            else if (!onGroundCheck.IsGrounded)
            {
                isJumpActionOn = true;
            }
            else if (onGroundCheck.IsGrounded)
            {
                isJumpActionOn = false;
            }
            animationController.JumpingAnim(isJumpActionOn);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health health = collision.ObjectHasHealth();
            if (health != null && collision.WasHitTopSide() && !collision.gameObject.CompareTag("EnemySaw"))
            {
                health.TakingHit(damage);
                jump.JumpAction();
            }
            else if (collision.gameObject.CompareTag("EnemySaw"))
            {
                jump.JumpAction();
            }
        }
        void PlaySoundOnHit(int currentHealth, int maxHealth)
        {
            if (currentHealth == maxHealth) return;
            audioSource.Play();
        }
    }
}
