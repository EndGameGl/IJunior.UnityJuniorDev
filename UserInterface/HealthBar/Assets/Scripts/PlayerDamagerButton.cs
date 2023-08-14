using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayerDamagerButton : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth _playerHealth;

    [SerializeField]
    private int _damageValue;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(DamagePlayer);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(DamagePlayer);
    }

    private void DamagePlayer()
    {
        _playerHealth.Damage(_damageValue);
    }
}
