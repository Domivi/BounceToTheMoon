using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{

    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime;
    public void LoadPlayScene()
    {
        StartCoroutine(LoadLevelTransition(SceneManager.GetActiveScene().buildIndex + 1));
    }

    private IEnumerator LoadLevelTransition(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
        yield return new WaitForSeconds(transitionTime);
        transition.SetTrigger("End");
    }
}
