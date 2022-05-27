using Project4.Concretes.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.Uis
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesButton()
        {
            GameManager.Instance.LoadScene();
            this.gameObject.SetActive(false);
        }
        public void NoButton()
        {
            GameManager.Instance.LoadMenuAndUi(1f);
        }
    }
}


