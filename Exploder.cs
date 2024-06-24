using UnityEngine;
using UnityEngine.UIElements;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explotionForce;
    [SerializeField] private float _explosionRadius;

    private Exploder _exploder;

    private void Start()
    {
        _exploder = GetComponent<Exploder>();
    }
    
    public void Explode(Rigidbody cube, Transform transform)
    {
        cube.AddExplosionForce(_explotionForce,transform.position, _explosionRadius);
    }
}
