
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject Spit;
    public float interval = 0.75f; //1.0f;

    void Start()
    {
        InvokeRepeating(nameof(ShootProjectile), interval, interval);
        
    }

    void ShootProjectile()
    {
        GameObject g = Instantiate(Spit, transform.position, Quaternion.identity);
    }
}
