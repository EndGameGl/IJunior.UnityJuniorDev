using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent<PlayerController>(out _))
        {
            gameObject.SetActive(false);
        }
    }
}
