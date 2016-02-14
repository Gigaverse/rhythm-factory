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
        
    }

    void Update()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(gameObject.GetComponent<Renderer>().material.color.r, gameObject.GetComponent<Renderer>().material.color.g, gameObject.GetComponent<Renderer>().material.color.b, gameObject.GetComponent<Renderer>().material.color.a - 0.015f));
    }
}