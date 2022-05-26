using Project4.Concretes.Combats;
using Project4.Concretes.Controllers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project4.Concretes.Managers
{ 
    public class CheckpointManager : MonoBehaviour
    {
        CheckpointController[] checkpointControllers;

        Health health;

        private void Awake()
        {
            checkpointControllers = GetComponentsInChildren<CheckpointController>();
            health = FindObjectOfType<PlayerController>().GetComponent<Health>();
        }
        private void Start()
        {
            health.OnHealthChanged += checkpointOnHealthChange;
        }

        void checkpointOnHealthChange(int maxHealth, int currentHealth)
        {
            health.transform.position = checkpointControllers.LastOrDefault(x => x.IsPassed).transform.position;
        }
    }
}
