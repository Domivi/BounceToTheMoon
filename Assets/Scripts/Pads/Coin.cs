using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float scoreToGive = 1000f;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameManager.instance.amassedCoinScore += scoreToGive;
            Destroy(gameObject);
        }
    }
}
