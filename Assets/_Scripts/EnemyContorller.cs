
using UnityEngine;
using System.Collections.Generic;

public class EnemyContorller : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private int _enemyCount = 5;

    [SerializeField]
    private ScoreManager _scoreManager;

    [SerializeField]
    private Transform _spawnTopLeft, spawntopRight, spawnBottomLeft, spawnBottomRight;

    void Start()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPostion = SelectRandomPosition();

        GameObject enemyObject = Instantiate(
            _enemyPrefab,
            spawnPostion,
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
        Transform selectedTransform = null;

        int randomValue = Random.Range(0, 4);
        SpawnPointType spawnType = (SpawnPointType)randomValue;

        switch (spawnType)
        {
            case SpawnPointType.TopLeft:
                selectedTransform = _spawnTopLeft;
                break;

            case SpawnPointType.TopRight:
                selectedTransform = spawntopRight;
                break;

            case SpawnPointType.BottomLeft:
                selectedTransform = spawnBottomLeft;
                break;

            case SpawnPointType.BottomRight:
                selectedTransform = spawnBottomRight;
                break;

            default:
                selectedTransform = _spawnTopLeft;
                break;
        }

        return selectedTransform.position +
            (Vector3)Random.insideUnitSphere;
    }

    public enum SpawnPointType
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }
}
