using Assets.Scripts;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
public abstract class Weapon : MonoBehaviour
{
    protected PlayerAnimator PlayerAnimator { get; private set; }

    protected virtual void Awake()
    {
        PlayerAnimator = GetComponent<PlayerAnimator>();
    }

    public abstract void Equip();
    public abstract void Unequip();
    public abstract void Use();
    public abstract void Die();
}
