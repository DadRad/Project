using UnityEngine;


public class CubeExplotion : MonoBehaviour
{
    [SerializeField] private Rigidbody _cubePrefab;
    [SerializeField] private float _explosionForce = 10f;

    private Camera _camera;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _camera = Camera.main;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                ExplodeCube(hit.transform.gameObject);
            }
        }
    }

    private void ExplodeCube(GameObject cube)
    {
        Transform parentTransform = cube.transform;

        Destroy(cube);
        SpawnCubes(parentTransform);

        
    }
    private void SpawnCubes(Transform parentTransform)
    {
        int minRandomValue = 2;
        int maxRandomValue = 7;
        int numCubesToCreate = Random.Range(minRandomValue, maxRandomValue);

        for (int i = 0; i < numCubesToCreate; i++)
        {
            Rigidbody newCube = Instantiate(_cubePrefab, parentTransform.position, Quaternion.identity);
            newCube.transform.localScale = parentTransform.localScale * 0.5f;
            newCube.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }
    private void PushCubes(GameObject cube)
    {
        Transform parentTransform = cube.transform;
    Vector3 explosionPosition = parentTransform.position;
    Vector3 explosionCenter = explosionPosition;

    Collider[] colliders = Physics.OverlapSphere(explosionCenter, 2f);

    foreach (Collider hit in colliders)
    {
        Rigidbody rigidBody = hit.GetComponent<Rigidbody>();

        if (rigidBody != null)
        {
            rigidBody.AddExplosionForce(_explosionForce, explosionCenter, 2f);
        }
    }
    }
}
