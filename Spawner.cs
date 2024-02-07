using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab; 
    [SerializeField] private float _movementSpeed = 5f; 
    [SerializeField] private float _spawnInterval = 2f; 

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private System.Collections.IEnumerator SpawnEnemies()
    {
        while (true)
        { 
            GameObject enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

            Vector3 direction = -transform.forward;

            EnemyMovement enemyMovement = enemy.AddComponent<EnemyMovement>();
            enemyMovement.SetSpeed(_movementSpeed);
            enemyMovement.SetDirection(direction);

            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}

public class EnemyMovement : MonoBehaviour
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
