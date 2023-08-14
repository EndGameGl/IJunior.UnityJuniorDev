using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayerHealerButton : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth _playerHealth;

    [SerializeField]
    private int _healValue;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(HealPlayer);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(HealPlayer);
    }

    private void HealPlayer()
    {
        _playerHealth.Heal(_healValue);
    }
}
