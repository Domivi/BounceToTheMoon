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
            // Checking the last index of the activeLevels list, in order to place the spawned coin on the last "level" of the list.
            var lastIndex = LevelSetup.singleton.activeLevels.Count;
            if (lastIndex == 0) return;
            GameObject spawnedCoin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
            spawnedCoin.transform.SetParent(LevelSetup.singleton.activeLevels[lastIndex-1].transform);
            // TODO: Parent it to the paddle object so that coins get destroyed as well.
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
