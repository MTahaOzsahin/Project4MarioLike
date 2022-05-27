using Project4.Concretes.Managers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Project4.Concretes.Uis
{
    public class DisplayScore : MonoBehaviour
    {
        TextMeshProUGUI scoreText;

        private void Awake()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            GameManager.Instance.OnScoreChanged += HandleScoreChange;
            GameManager.Instance.IncreaseScore();
        }
        private void OnDisable()
        {
            GameManager.Instance.OnScoreChanged -= HandleScoreChange;
        }

        private void HandleScoreChange(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}

