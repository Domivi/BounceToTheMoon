using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetup : MonoBehaviour
{
    
    public static LevelSetup singleton;
    [SerializeField] private List<GameObject> activeLevels = new List<GameObject>();
    [SerializeField] private GameObject levelPrefab; 
    [SerializeField] private GameObject boosterPrefab;
    [SerializeField] private GameObject paddlePrefab;

    [SerializeField] private int yOffSet = 4;
    [SerializeField] private float xOffSet; 

    [SerializeField] private int ySpawnCount;
    [SerializeField] private int xSpawnCount;

    [SerializeField] private int generalSpawnCount = 0;

    [SerializeField] private Vector3 initialSpawnPoint = new Vector3(0f, 8f, 0f);


    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    void Start()
    {
        GenerateLevel();
    }

    public void GenerateLevel()
    {
        activeLevels.Add(Instantiate(levelPrefab, initialSpawnPoint, Quaternion.identity));
        for (int i = 0; i < xSpawnCount; i++)
        {
            for (int j = 0; j < ySpawnCount; j++)
            {
                Vector3 paddlePosition = new Vector3(Random.Range(Coords.left.position.x, Coords.right.position.x), Random.Range(Coords.bottom.position.y + ((generalSpawnCount + 1) * yOffSet), Coords.top.position.y + ((generalSpawnCount + 1) * yOffSet)), 0f);
                GameObject paddle = Instantiate(paddlePrefab, paddlePosition, Quaternion.identity);
                if(activeLevels.Count > 3)
                {
                    paddle.transform.SetParent(activeLevels[3].transform);
                }
                else
                {
                    paddle.transform.SetParent(activeLevels[generalSpawnCount].transform);
                }
            }
        }
        initialSpawnPoint = new Vector3(0f, (yOffSet * generalSpawnCount + 8f), 0f);
        generalSpawnCount++;

        if (activeLevels.Count > 3)
        {
            Destroy(activeLevels[activeLevels.Count - 4]);
            activeLevels.RemoveAt(activeLevels.Count - 4);
        }
    }
}
