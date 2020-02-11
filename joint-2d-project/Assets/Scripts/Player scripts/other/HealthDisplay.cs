using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Text health_counter;
    public PlayerStatsControll stats;
    void Start()
    {
        
    }
    void LateUpdate()
    {
        health_counter.text = "HP: " + stats.playerHealth;
    }
}
