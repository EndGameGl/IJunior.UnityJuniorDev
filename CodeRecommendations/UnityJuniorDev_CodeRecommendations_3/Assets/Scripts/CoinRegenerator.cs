using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinRegenerator : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _minRespawnInterval;
    [SerializeField] private float _maxRespawnInterval;

    private float _currentTimer;
    private float _currentSpawnInterval;
    private GameObject _coinInstance;

    private void Awake()
    {
        _currentSpawnInterval = GetNextRespawnTime();
    }

    private void Update()
    {
        if (_coinInstance is { activeSelf: true })
            return;

        _currentTimer += Time.deltaTime;
        if (_currentTimer >= _currentSpawnInterval)
        {
            SpawnCoin();
            _currentTimer = 0;
            _currentSpawnInterval = GetNextRespawnTime();
        }
    }

    private void SpawnCoin()
    {
        if (_coinInstance is null)
        {
            _coinInstance = Instantiate(_prefab, transform);
            return;
        }

        if (!_coinInstance.activeSelf)
        {
            _coinInstance.SetActive(true);
        }
    }

    private float GetNextRespawnTime() => Random.Range(_minRespawnInterval, _maxRespawnInterval);
}