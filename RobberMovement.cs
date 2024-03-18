using UnityEngine;

public class RobberMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * _movementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * _movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            RotatePlayer(-1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            RotatePlayer(1);
        }
    }

    void RotatePlayer(int direction)
    {
        float rotation = direction * _rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
    }
}