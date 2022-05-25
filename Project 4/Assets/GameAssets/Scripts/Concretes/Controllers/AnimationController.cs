using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.Controllers
{
    public class AnimationController : MonoBehaviour
    {
        Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void RunningAnim(float horizontal)
        {
            float mathfHorizontalValue = Mathf.Abs(horizontal);
            if (animator.GetFloat("moveSpeed") == mathfHorizontalValue) return;

            animator.SetFloat("moveSpeed", mathfHorizontalValue);
        }
        public void JumpingAnim(bool isJumpActionOn)
        {
            animator.SetBool("isJumpActionOn", isJumpActionOn);   
        }
    }
}
