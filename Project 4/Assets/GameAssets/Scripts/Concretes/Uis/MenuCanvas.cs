using Project4.Concretes.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.Uis
{
    public class MenuCanvas : MonoBehaviour
    {
        [SerializeField] MenuPanel menuPanel;

        private void OnEnable()
        {
            GameManager.Instance.OnSceneChanged += HandleSceneChange;
        }
        private void OnDisable()
        {
            GameManager.Instance.OnSceneChanged -= HandleSceneChange;
        }

        private void HandleSceneChange(bool isActive)
        {
            if (isActive == menuPanel.gameObject.activeSelf) return;
            menuPanel.gameObject.SetActive(isActive);

            
        }
    }
}
