using Project4.Concretes.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.Uis
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] GameObject gamePlayObject;
        [SerializeField] GameOverPanel gameOverPanel;

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
            if (!isActive == gamePlayObject.activeSelf) return;
            gamePlayObject.SetActive(!isActive);
        }
        public void ShowGameOverPanel()
        {
            gameOverPanel.gameObject.SetActive(true);
            GameManager.Instance.Score = 0;
        }
    }
}
