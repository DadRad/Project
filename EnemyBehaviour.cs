using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private float speed;
    private Vector3 direction;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
