using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    private float _speed = 0.05f;
    [SerializeField] private Vector3 _direction;
    void Update()
    {
        transform.Translate(_direction);
    }
}
