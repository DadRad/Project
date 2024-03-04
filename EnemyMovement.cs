using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float _speed;
    private Vector3 _direction;

    public void SetSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }

    public void SetDirection(Vector3 newDirection)
    {
        _direction = newDirection;
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}
