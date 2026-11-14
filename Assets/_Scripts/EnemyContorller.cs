
using UnityEngine;

public class EnemyContorller : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private ScoreManager _scoreManager;

    [SerializeField]
    private Transform _spawnTopLeft, spawntopRight,
        spawnBottomLeft, spawnBottomRight;

    [SerializeField]
    private Transform _spawnTopMiddle, _spawnBottomMiddle,
        _spawnCenter;

    void Start()
    {
        int enemyCount = DifficultyManager.EnemyCount;

        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = SelectRandomPosition();

        GameObject enemyObject = Instantiate(
            _enemyPrefab,
            spawnPosition,
            Quaternion.identity
        );

        Enemy enemyScript = enemyObject.GetComponent<Enemy>();

        if (enemyScript != null)
        {
            enemyScript.OnDie += SpawnEnemy;
            enemyScript.OnDie += () => _scoreManager.AddPoints(10);
        }
    }

    private Vector3 SelectRandomPosition()
    {
        Transform[] spawnPoints =
        {
            _spawnTopLeft,
            spawntopRight,
            spawnBottomLeft,
            spawnBottomRight,
            _spawnTopMiddle,
            _spawnBottomMiddle,
            _spawnCenter
        };

        int activeSpawnPoints = DifficultyManager.SpawnPointCount;

        activeSpawnPoints = Mathf.Min(activeSpawnPoints, 7);

        int randomValue = Random.Range(0, activeSpawnPoints);

        return spawnPoints[randomValue].position +
            (Vector3)Random.insideUnitSphere;
    }
}
