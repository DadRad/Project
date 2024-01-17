using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionManipulator : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _scaleSpeed;
    [SerializeField] private float _rotationSpeed;

    void Update()
    {
        Vector3 moveDirection = transform.forward;
        moveDirection = _moveSpeed * moveDirection;

        transform.Translate(moveDirection, Space.World);

        transform.Rotate(0, _rotationSpeed, 0);

        transform.localScale += new Vector3(_scaleSpeed, _scaleSpeed, _scaleSpeed) * Time.deltaTime;
    }
}
