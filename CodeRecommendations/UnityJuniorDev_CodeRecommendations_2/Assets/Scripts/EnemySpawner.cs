using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    [Tooltip("Positions from where the enemies will spawn.")] [SerializeField]
    private List<Transform> _positions;

    [SerializeField] private BasicEnemy _enemyPrefab;
    [SerializeField] private float _interval;
    [SerializeField] private int _poolSize;

    private Coroutine _enemySpawnerCoroutine;
    private WaitForSeconds _awaiter;
    private readonly List<BasicEnemy> _spawnedEnemies = new();

    private void Start()
    {
        _awaiter = new WaitForSeconds(_interval);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (enabled)
        {
            if (GetNextEnemyInstance(out var enemy))
            {
                SetRandomPosition(enemy);
                enemy.SetTarget(_target.transform);
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

        if (newEnemy is null && _spawnedEnemies.Count < _poolSize)
        {
            newEnemy = Instantiate(_enemyPrefab);
            _spawnedEnemies.Add(newEnemy);
            return true;
        }

        return false;
    }

    private void SetRandomPosition(BasicEnemy enemy)
    {
        var pointToSpawn = _positions[Random.Range(0, _positions.Count)];
        enemy.transform.position = pointToSpawn.position;
    }
}