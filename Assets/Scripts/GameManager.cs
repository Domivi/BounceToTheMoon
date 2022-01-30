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
    public float score;

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
        score += Mathf.Round(player.maxHeight * scoreMultiplier);  
        if (score != previouslyCheckedScore)
        {
            previouslyCheckedScore = score;
            scoreText.text = score.ToString();
        }
    }
}
