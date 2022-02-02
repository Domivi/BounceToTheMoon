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
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(LoadLevelTransition(SceneManager.GetActiveScene().buildIndex + 1));
        }
        else
        {
            StartCoroutine(LoadLevelTransition(SceneManager.GetActiveScene().buildIndex));
        }
    }

    private IEnumerator LoadLevelTransition(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
