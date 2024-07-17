
using UnityEngine;

public class CollisionRules : MonoBehaviour
{
    public AudioClip splashSound;

        private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag =="Player" || collision.gameObject.tag == "Arrow")
        {
            Physics2D.IgnoreCollision(collision.transform.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        else if(collision.gameObject.tag == "Slimeboss")
        {
                Destroy(gameObject);
        }
        else if(collision.gameObject.tag != "Wall")
        {
                AudioSource.PlayClipAtPoint(splashSound, transform.position, 1f);
                Destroy(collision.gameObject);
                Timer.scoreNum += 1;
                Destroy(gameObject);
        }
    }
}
