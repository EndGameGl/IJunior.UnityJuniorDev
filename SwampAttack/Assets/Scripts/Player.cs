using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField]
    public int Health { get; private set; }

    [field: SerializeField]
    public Weapon Weapon { get; private set; }
}
