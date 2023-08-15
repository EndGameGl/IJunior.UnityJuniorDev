using Assets.Scripts;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
public abstract class Weapon : MonoBehaviour
{
    protected PlayerAnimator PlayerAnimator { get; private set; }

    public abstract string WeaponAnimationName { get; protected set; }

    protected virtual void Awake()
    {
        PlayerAnimator = GetComponent<PlayerAnimator>();
    }

    public abstract void Equip();
    public abstract void Unequip();
    public abstract void Use();
}
