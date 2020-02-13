using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    public Text coin_counter;
    public PlayerStatsControll stats;
    void LateUpdate()
    {
        coin_counter.text = stats.coinCounter.ToString();
    }
}
