using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetup : MonoBehaviour
{
    
    public static LevelSetup singleton;
    [SerializeField] public List<GameObject> activeLevels = new List<GameObject>();
    [SerializeField] private GameObject levelPrefab; 
    [SerializeField] private GameObject boosterPrefab;
    [SerializeField] private GameObject paddlePrefab;
    [SerializeField] private int yOffSetPerLoop = 4;
    // [SerializeField] private float minYOffSet = 0.1f;
    // [SerializeField] private float maxYOffSet = 0.3f;
    [SerializeField] private float addedYOffSet; 
    [SerializeField] private int minPaddleSpawnCount;
    [SerializeField] private int maxPaddleSpawnCount;
    [SerializeField] private int levelSpawnCount = 0;
    [SerializeField] private Vector3 initialSpawnPoint = new Vector3(0f, 8f, 0f);
    private const float padSpawnPositionCap = 3.35f;

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

    void OnEnable()
    {
        GameOver.onGameOver += GameoverDestroyObjects;
    }

    void OnDisable()
    {
        GameOver.onGameOver -= GameoverDestroyObjects;
    }

    public void GenerateLevel()
    {
        int paddleSpawnCountRoll = Random.Range(minPaddleSpawnCount, maxPaddleSpawnCount);
        activeLevels.Add(Instantiate(levelPrefab, initialSpawnPoint, Quaternion.identity));
        float currentLoopYMax = Coords.bottom.position.y + ((levelSpawnCount + 1) * yOffSetPerLoop) + 4f;
        addedYOffSet = currentLoopYMax - 4f;

        for (int i = 0; i < paddleSpawnCountRoll; i++)
        {
            float yOffSetRoll = yOffSetPerLoop / (float)paddleSpawnCountRoll;
            float ySpawnPosition = Mathf.Clamp(addedYOffSet, currentLoopYMax - yOffSetPerLoop, currentLoopYMax);
            addedYOffSet += yOffSetRoll;
            
            GameObject paddleToInstantiate =  selectPaddleVariant();
            Vector3 paddlePosition = new Vector3(Random.Range(-padSpawnPositionCap, padSpawnPositionCap), ySpawnPosition, 0f);
            GameObject paddle = Instantiate(paddleToInstantiate, paddlePosition, Quaternion.identity);

            if(activeLevels.Count > 3)
            {
                paddle.transform.SetParent(activeLevels[3].transform);
            }
            else
            {
                paddle.transform.SetParent(activeLevels[levelSpawnCount].transform);
            }
        }

        initialSpawnPoint = new Vector3(0f, (yOffSetPerLoop *  levelSpawnCount + 8f), 0f);
        levelSpawnCount++;

        // Destroy previous "level blocks", so that only 3 are available at a time. 
        if (activeLevels.Count > 3)
        {
            Destroy(activeLevels[activeLevels.Count - 4]);
            activeLevels.RemoveAt(activeLevels.Count - 4);
        }
    }

    private GameObject selectPaddleVariant()
    {
        float boosterRoll = 0.25f; 
        float randomRoll = Random.Range(0f, 1f);
        GameObject paddleToInstantiate; 

        if (randomRoll > boosterRoll)
        {
            paddleToInstantiate = paddlePrefab;
            return paddleToInstantiate;
        }
        else 
        {
            paddleToInstantiate = boosterPrefab;
            return paddleToInstantiate;
        }
    }

    public void GameoverDestroyObjects()
    {
        while (activeLevels.Count > 0)
        {
            Destroy(activeLevels[0]);
            activeLevels.RemoveAt(0);    
        }
    }
}   
