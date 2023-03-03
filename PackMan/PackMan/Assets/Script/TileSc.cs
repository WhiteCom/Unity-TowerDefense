using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSc : MonoBehaviour
{
    // Tile Info

    public int weight;

    public float x, z;

    private void Awake()
    {
        x = transform.position.x;
        z = transform.position.z;
    }
}
