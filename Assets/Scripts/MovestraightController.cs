using UnityEngine;

public class MovestraightController : MonoBehaviour
{

    public Vector2 velocity;
    new Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidbody.velocity = velocity;
    }
}


