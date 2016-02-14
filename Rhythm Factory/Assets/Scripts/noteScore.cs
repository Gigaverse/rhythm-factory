using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Projectile behavior
/// </summary>
public class noteScore : MonoBehaviour
{
    void Start()
    {
        // 2 - Limited time to live to avoid any leak
        Destroy(gameObject, 1); // 1sec
    }
}