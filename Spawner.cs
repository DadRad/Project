using System.Data.SqlTypes;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Rigidbody _cubePrefab;

    private Camera _camera;
    private Exploder _exploder;

    private void Awake()
    {
        _camera = Camera.main;
        Rigidbody _cube = GetComponent<Rigidbody>();
        _exploder = GetComponent<Exploder>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _camera = Camera.main;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                CubeSpawner(hit.transform, hit.collider.gameObject);
                _exploder.Explode(_cubePrefab, hit.transform);
            }
        }
    }

    private void CubeSpawner(Transform parentTransform, GameObject cube)
    {
        int minRandomValue = 2;
        int maxRandomValue = 7;
        int numCubesToCreate = Random.Range(minRandomValue, maxRandomValue);

        Destroy(cube);

        for (int i = 0; i < numCubesToCreate; i++)
        {
            Rigidbody newCube = Instantiate(_cubePrefab, parentTransform.position, Quaternion.identity);
            newCube.transform.localScale = parentTransform.localScale * 0.5f;
            newCube.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }   
    }
}
