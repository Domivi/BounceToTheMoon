using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private float scoreMultiplier;
    [SerializeField] private Player player;
    public static GameManager instance;
    private float previouslyCheckedScore = 0f;
    public float heightScore;
    private float combinedScore;
    public float amassedCoinScore;
    public float highestSessionScore;

    void Awake()
    {
        if(instance!= null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }
    void Update()
    {
        heightScore = Mathf.Round(player.maxHeight * scoreMultiplier);  
        if (heightScore != previouslyCheckedScore)
        {
            previouslyCheckedScore = heightScore;
            combinedScore = heightScore + amassedCoinScore;
            scoreText.text = combinedScore.ToString();
        }
    }

    float HighestSessionScore()
    {
        if(!(combinedScore > highestSessionScore)) return highestSessionScore;
        highestSessionScore = combinedScore;
        return highestSessionScore;
    }
}
