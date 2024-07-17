using UnityEngine;
using UnityEngine.SceneManagement;

public class SpitCollisionRules : MonoBehaviour
{

    [SerializeField]
    private int damageAmount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slime"))  
        {
            Physics2D.IgnoreCollision(collision.transform.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        else if (collision.gameObject.CompareTag("Spit"))
        {
            Physics2D.IgnoreCollision(collision.transform.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        else if(collision.gameObject.CompareTag("Player")) 
        { 
            //collision with Player
            var playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }
            Destroy(gameObject); // DEstroy Spit
        }
        else
        {
            
        }
    }
}