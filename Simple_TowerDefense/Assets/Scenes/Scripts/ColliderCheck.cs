using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    public GameObject gameOverUI;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BossCrown(Clone)" || other.gameObject.name == "BossCrown")
        {
            gameOverUI.SetActive(true);
        }
    }
}
