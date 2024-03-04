using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyMovement _enemyPrefab;
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private Transform _target;

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
            EnemyMovement enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            Vector3 direction = _target.position - enemy.transform.position;

            enemy.SetSpeed(_movementSpeed);
            enemy.SetDirection(direction);

            yield return _waitInterval;
        }
    }
}