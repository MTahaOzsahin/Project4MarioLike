using Project4.Concretes.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.Uis
{
    public class EndCanvas : MonoBehaviour
    {
        public void YesButton()
        {
            GameManager.Instance.LoadScene();
            Time.timeScale = 1f;
        }
        public void NoButton()
        {
            GameManager.Instance.ExitGame();
        }
    }
}
