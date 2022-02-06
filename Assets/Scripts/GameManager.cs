using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] gameOverUI = new GameObject[5];
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Player player;
    [SerializeField] private float scoreMultiplier;
    [SerializeField] GameObject coinText;
    public static GameManager instance;
    private float previouslyCheckedScore = 0f;
    public float heightScore;
    private float combinedScore;
    public float amassedCoinScore;
    public float highestSessionScore;

    void OnEnable()
    {
        GameOver.onGameOver += SwitchGameOverTextsStatus;
        GameOver.onGameOver += updateGameOverUIContent;
    }

    void OnDisable()
    {
        GameOver.onGameOver -= SwitchGameOverTextsStatus;
        GameOver.onGameOver -= updateGameOverUIContent;
    }
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
        //Handle height score and changing the score text
        heightScore = Mathf.Round(player.maxHeight * scoreMultiplier);  
        combinedScore = heightScore + amassedCoinScore;
        previouslyCheckedScore = heightScore;
        scoreText.text = combinedScore.ToString();
        // if (heightScore != previouslyCheckedScore)
        // {
        //     previouslyCheckedScore = heightScore;
        //     scoreText.text = combinedScore.ToString();
        // }
    }

    public float HighestSessionScore()
    {
        if(!(combinedScore > highestSessionScore)) return highestSessionScore;
        highestSessionScore = combinedScore;
        return highestSessionScore;
    }
    public void AddCoinScore (float scoreToGive)
    {
        amassedCoinScore += scoreToGive;
        GameObject text = Instantiate(coinText);
        text.transform.SetParent(GameObject.FindGameObjectWithTag("FrontCanvas").transform, false);
    }

    // Enables or disables Game Over Texts
    private void SwitchGameOverTextsStatus()
    {
        if(gameOverUI[0].activeSelf)
        {
            for (int UI = 0; UI < gameOverUI.Length; UI++)
            {
                gameOverUI[UI].SetActive(false);
            }
        }        
        for (int UI = 0; UI < gameOverUI.Length; UI++)
        {
            gameOverUI[UI].SetActive(true);
        }
    }

    private void updateGameOverUIContent()
    {
        gameOverUI[1].GetComponent<TextMeshProUGUI>().SetText($"Final Score:   {combinedScore}");
        float highScore = HighestSessionScore();
        gameOverUI[2].GetComponent<TextMeshProUGUI>().SetText($"High Score:   {highScore}");
    }
}
