using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Project4.Concretes.Uis
{
    public class DisplayHealth : MonoBehaviour
    {
        TextMeshProUGUI healthText;
        private void Awake()
        {
            healthText = GetComponent<TextMeshProUGUI>();
        }
        public void WriteHealth(int currentHealth,int maxHealth)
        {
            healthText.text = currentHealth.ToString();
        }
    }
}
