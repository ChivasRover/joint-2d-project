using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerStatsControll playerStats = collision.gameObject.GetComponent<PlayerStatsControll>();
        if(collision.gameObject.tag == "Player")
        {
            playerStats.coinCounter++;
            Destroy(gameObject);
        }
    }
}
