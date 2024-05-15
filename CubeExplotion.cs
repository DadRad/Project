using UnityEngine;


public class CubeExplotion : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private float _explosionForce = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                ExplodeCube(hit.transform.gameObject);
            }
        }
    }

    void ExplodeCube(GameObject cube)
    {
        Transform parentTransform = cube.transform;
        Vector3 explosionPosition = parentTransform.position;

        Destroy(cube);

        Vector3 explosionCenter = explosionPosition;
        Collider[] colliders = Physics.OverlapSphere(explosionCenter, 2f);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(_explosionForce, explosionCenter, 2f);
            }
        }

        int minRandomValue = 2;
        int maxRandomValue = 7;

        int numCubesToCreate = Random.Range(minRandomValue, maxRandomValue);
        for (int i = 0; i < numCubesToCreate; i++)
        {
            GameObject newCube = Instantiate(_cubePrefab, parentTransform.position, Quaternion.identity);
            newCube.transform.localScale = parentTransform.localScale * 0.5f;
            newCube.GetComponent<Renderer>().material.color = Random.ColorHSV();

            Rigidbody rb = newCube.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = true;
            }
        }
    }
}
