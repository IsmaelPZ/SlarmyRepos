using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrow;

    public Transform arrowSpawner;

    public AudioClip bowString;

    public float Power;
    public void spawnArrows()
    {
       GameObject ArrowTarget = Instantiate(arrow, transform.position, transform.rotation);
        Rigidbody2D rb = ArrowTarget.GetComponent<Rigidbody2D>();

        Vector2 forceDirection = ArrowTarget.transform.right; 
        rb.AddForce(forceDirection * Power, ForceMode2D.Impulse);
        AudioSource.PlayClipAtPoint(bowString, transform.position, 1f);
        //rb.AddForce(arrowSpawner.right * Power, ForceMode2D.Impulse);
    }
}
