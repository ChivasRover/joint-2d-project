using UnityEngine;

public class EnemyDamageOutput : MonoBehaviour
{
    public int damagePower;

    private void OnCollisionStay2D(Collision2D other)
    {
        PlayerStatsControll playerStatsControll = other.gameObject.GetComponent<PlayerStatsControll>();
        if (other.gameObject.tag == "Player")
        {
            playerStatsControll.TakeDamage(damagePower);
        }
    }
}
