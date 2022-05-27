using Project4.Concretes.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.Uis
{
    public class MenuPanel : MonoBehaviour
    {
        public void StartButton()
        {
            GameManager.Instance.LoadScene(1);
        }
        public void ExitGame()
        {
            GameManager.Instance.ExitGame();
        }
    }
}
