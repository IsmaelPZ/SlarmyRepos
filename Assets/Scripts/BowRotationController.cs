using UnityEngine;

public class BowRotationController : MonoBehaviour
{
    public static Vector2 mousePos;

    private void Update()
    {
        lookAtMouse();
    }
    private void lookAtMouse()
    {
        mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - (Vector2)transform.position;
        transform.right = direction;
    }
}
