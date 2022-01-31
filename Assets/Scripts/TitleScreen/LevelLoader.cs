using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    private GameObject scoreText;
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadPlayScene()
    {
        StartCoroutine(LoadLevelTransition(SceneManager.GetActiveScene().buildIndex + 1));
    }

    private IEnumerator LoadLevelTransition(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
        
        // Tonight we're having spaghettiiiiii
        yield return new WaitForSeconds(transitionTime);
        transition.SetTrigger("End");
        yield return new WaitForSeconds(transitionTime);
        scoreText = GameObject.Find("FrontCanvas");
        scoreText.transform.GetChild(0).gameObject.SetActive(true);
    }
}
