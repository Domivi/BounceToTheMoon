using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetup : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> activeLevels = new List<GameObject>();
    [SerializeField] private GameObject levelPrefab; 
    [SerializeField] private GameObject boosterPrefab;
    [SerializeField] private GameObject paddlePrefab;

    [SerializeField] private float yOffSet;
    [SerializeField] private float xOffSet; 

    [SerializeField] private int ySpawnCount;
    [SerializeField] private int xSpawnCount;

    [SerializeField] private int generalSpawnCount = 0;

    [SerializeField] private Vector3 initialSpawnPoint = new Vector3(0f, 4f, 0f);


    // void Awake()
    // {
    //     if (instance == null)
    //     {
    //         instance = this;
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    
    void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        generalSpawnCount++;
        activeLevels.Add(Instantiate(levelPrefab, initialSpawnPoint, Quaternion.identity));
        for (int i = 0; i < xSpawnCount; i++)
        {
            for (int j = 0; j < ySpawnCount; j++)
            {
                Vector3 paddlePosition = new Vector3(Random.Range(Coords.left.position.x, Coords.right.position.x), Random.Range(Coords.bottom.position.y + (generalSpawnCount * 4f), Coords.top.position.y + (generalSpawnCount * 4f)), 0f);
                GameObject paddle = Instantiate(paddlePrefab, paddlePosition, Quaternion.identity);
                paddle.transform.SetParent(activeLevels[0].transform);
            }
        }
    }
}
