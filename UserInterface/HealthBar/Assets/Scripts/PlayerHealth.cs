using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [field: SerializeField]
    public int Health { get; private set; }

    [field: SerializeField]
    public int MaxHealth { get; private set; }

    [field: SerializeField]
    public int MinHealth { get; private set; }

    public event Action<int> HealthChanged;

    public void Damage(int amount)
    {
        Health -= amount;

        if (Health < 0)
            Health = 0;

        HealthChanged?.Invoke(Health);
    }

    public void Heal(int amount)
    {
        Health += amount;

        if (Health > MaxHealth)
            Health = MaxHealth;

        HealthChanged?.Invoke(Health);
    }
}
