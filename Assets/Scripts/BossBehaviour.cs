using UnityEngine;
using System.Collections;

public class BossBehaviour : MonoBehaviour
{
    public float bossSpeed = 3;
    private bool isFollowingPlayer = true;
    private float followDuration = 4f;
    private float shootDuration = 3f;
    public float fireRate = 0.05f;
    private float nextFireTime = 0f;

    public Transform bulletSpawnPoint;
    public GameObject Spit;
    public Collider2D bossCollider;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(BossRoutine());
    }

    IEnumerator BossRoutine()
    {
        while (true)
        {
            
            isFollowingPlayer = true;
            bossCollider.enabled = true;
            yield return new WaitForSeconds(followDuration);

            
            isFollowingPlayer = false;
            bossCollider.enabled = false;
            yield return new WaitForSeconds(shootDuration);
        }
    }

    void ShootProjectile()
    {
        GameObject g = Instantiate(Spit, transform.position, Quaternion.identity);
    }

    void Update()
    {
        if (isFollowingPlayer)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                Vector2 playerPos = (player.transform.position - transform.position).normalized;
                rb.velocity = playerPos * bossSpeed;
            }
        }
        else
        {
            IdleAndShoot();         
            

        }
    }

    void IdleAndShoot()
    {
        rb.velocity = Vector2.zero;
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(Spit, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}