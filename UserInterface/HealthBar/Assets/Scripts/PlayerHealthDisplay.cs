using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class PlayerHealthDisplay : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth _playerHealth;

    [SerializeField]
    private Gradient _gradient;

    [SerializeField]
    private Image _fillImage;

    [SerializeField]
    private float _fillSpeed;

    private Slider _slider;
    private float _targetValue;
    private Coroutine _healthUpdater;
    private WaitForEndOfFrame _frameAwaiter;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.value = (float)_playerHealth.Health / _playerHealth.MaxHealth;
        _targetValue = _slider.value;
        _fillImage.color = _gradient.Evaluate(_targetValue);
    }

    private void OnEnable()
    {
        _playerHealth.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _playerHealth.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int newValue)
    {
        _targetValue = (float)newValue / _playerHealth.MaxHealth;
        if (_healthUpdater == null)
        {
            _healthUpdater = StartCoroutine(ChangeFillValue());
        }
    }

    private IEnumerator ChangeFillValue()
    {
        while (_slider.value != _targetValue)
        {
            _fillImage.color = _gradient.Evaluate(_targetValue);
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, Time.deltaTime * _fillSpeed);
            yield return _frameAwaiter;
        }
        _healthUpdater = null;
    }
}
