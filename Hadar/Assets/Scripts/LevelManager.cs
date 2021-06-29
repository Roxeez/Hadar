using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeLevel()
    {
        var sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (sceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            sceneIndex = 0;
        }

        StartCoroutine(SmoothSceneChange(sceneIndex));
    }

    private IEnumerator SmoothSceneChange(int sceneIndex)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneIndex);
    }
}
