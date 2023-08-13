using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinRegenerator : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _minRespawnInterval;
    [SerializeField] private float _maxRespawnInterval;

    private GameObject _coinInstance;

    private Coroutine _coinSpawner;

    private void OnEnable()
    {
        _coinSpawner = StartCoroutine(SpawnCoins());
    }

    private void OnDisable()
    {
        StopCoroutine(_coinSpawner);
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

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            SpawnCoin();
            yield return new WaitForSeconds(GetNextRespawnTime());          
        }
    }
}