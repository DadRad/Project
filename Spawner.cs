using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyBehaviour _enemyPrefab;
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _spawnInterval = 2f;

    private WaitForSeconds _waitInterval;

    private void Start()
    {
        _waitInterval = new WaitForSeconds(_spawnInterval);

        StartCoroutine(SpawnEnemies());
    }

    private System.Collections.IEnumerator SpawnEnemies()
    {
        while (true)
        {
            EnemyBehaviour enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            Vector3 direction = -transform.forward;

            enemy.SetSpeed(_movementSpeed);
            enemy.SetDirection(direction);

            yield return _waitInterval;
        }
    }
}
