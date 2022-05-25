using Project4.Abstracts.Inputs;
using Project4.Concretes.Combats;
using Project4.Concretes.Inputs;
using Project4.Concretes.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        Mover mover;
        IPlayerInputs pcInputs;
        AnimationController animationController;
        Jump jump;
        OnGroundCheck onGroundCheck;
        Health health;
        Damage damage;

        float horizontal;
        float vertical;

        private void Awake()
        {
            mover = GetComponent<Mover>();
            jump = GetComponent<Jump>();
            onGroundCheck = GetComponent<OnGroundCheck>();
            pcInputs = new PcInputs();
            animationController = GetComponent<AnimationController>();
            health = GetComponent<Health>();
            damage = GetComponent<Damage>();
        }
        private void Update()
        {
            PlayerJumpControl();
        }
        private void FixedUpdate()
        {
            GetAxis();
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
            Health health = collision.collider.GetComponent<Health>();
            if (health != null)
            {
                health.TakingHit(damage);
            }
        }
    }
}
