using UnityEngine;

public class EnemyDamageOutput : MonoBehaviour
{
    public int damagePower;

    private void OnCollisionStay2D(Collision2D other)
    {
        PlayerHealthControll playerHealthControll = other.gameObject.GetComponent<PlayerHealthControll>();
        if (other.gameObject.tag == "Player")
        {
            playerHealthControll.TakeDamage(damagePower);
        }
    }
}
