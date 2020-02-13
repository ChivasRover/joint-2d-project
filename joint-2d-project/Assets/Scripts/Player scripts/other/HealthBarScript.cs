using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider healthBar;
    public PlayerStatsControll playerStats;
    void Start()
    {
        healthBar.maxValue = 5;
        healthBar.value = healthBar.maxValue;
    }

    void LateUpdate()
    {
        healthBar.value = playerStats.playerHealth;
    }
}
