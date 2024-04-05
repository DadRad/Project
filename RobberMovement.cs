using UnityEngine;

public class RobberMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    private void Update()
    {
        Move();
        SideMove();
    }

    private void Move()
    {
        float moveInput = Input.GetAxisRaw("Vertical");

        float moveAmount = moveInput * _movementSpeed * Time.deltaTime;

        transform.Translate(0, 0, moveAmount);
    }
    private void SideMove()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        float moveAmount = moveInput * _movementSpeed * Time.deltaTime;

        transform.Translate(moveAmount, 0, 0);
    }
}