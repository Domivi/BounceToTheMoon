using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotOnPaddleSpawn : MonoBehaviour
{
    [SerializeField] private int coinSpawnRate = 5;
    [SerializeField] private GameObject coinPrefab; 
    void Start()
    {
        if (spawnCoinOnPaddle())
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
    }
    private bool spawnCoinOnPaddle()
    {
        int roll = Mathf.RoundToInt(Random.Range(0, 100));
        if (roll < coinSpawnRate)
        {
            return true;
        } 
        else
        {
            return false;
        }
    }
}
