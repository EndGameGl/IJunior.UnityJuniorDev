using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    private List<BasicEnemy> _spawnedEnemies = new();

    [SerializeField] private GameObject target;
    [SerializeField] private List<Transform> spawnPositions;
    [SerializeField] private BasicEnemy basicEnemyPrefab;
    [SerializeField] private float spawnInterval;
    [SerializeField] private int poolSize;

    private Coroutine _enemySpawnerCoroutine;
    private WaitForSeconds _awaiter;

    private void Start()
    {
        _awaiter = new WaitForSeconds(spawnInterval);
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (enabled)
        {
            if (GetNextEnemyInstance(out var enemy))
            {
                SetEnemyPositionToRandomSpawnPoint(enemy);
                enemy.SetTarget(target.transform);
            }

            yield return _awaiter;
        }
    }

    private bool GetNextEnemyInstance(out BasicEnemy newEnemy)
    {
        newEnemy = _spawnedEnemies.FirstOrDefault(x => !x.gameObject.activeSelf);

        if (newEnemy is not null)
        {
            newEnemy.gameObject.SetActive(true);
            return true;
        }

        if (newEnemy is null && _spawnedEnemies.Count < poolSize)
        {
            newEnemy = Instantiate(basicEnemyPrefab);
            _spawnedEnemies.Add(newEnemy);
            return true;
        }

        return false;
    }

    private void SetEnemyPositionToRandomSpawnPoint(BasicEnemy enemy)
    {
        var pointToSpawn = spawnPositions[Random.Range(0, spawnPositions.Count)];
        enemy.transform.position = pointToSpawn.position;
    }
}