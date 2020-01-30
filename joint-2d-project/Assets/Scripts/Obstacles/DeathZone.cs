using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject respawn;
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player") {
            other.gameObject.transform.position = respawn.transform.position;
        }
    }
}
