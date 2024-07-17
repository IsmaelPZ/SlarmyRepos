using UnityEngine;

public class CollisionPlayerEnemy : MonoBehaviour
{
    [SerializeField]
    private int damageAmount;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slime" || collision.gameObject.tag == "Spit")
        {
            Physics2D.IgnoreCollision(collision.transform.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (collision.gameObject.tag == "Player")
        {

            var playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageAmount);
            playerHealth.Blinking(true); 
        }
    }
}
