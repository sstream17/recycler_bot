using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject finishMenu;
    public Image fadeImage;

    private bool pauseMenuIsActive = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        finishMenu.SetActive(false);
    }

    public void pause()
    {
        Debug.Log("Clicked");
        if (pauseMenuIsActive)
        {
            Time.timeScale = 1f;
            pauseMenuIsActive = false;
            pauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            pauseMenuIsActive = true;
            pauseMenu.SetActive(true);
        }
    }

    public void OnLevelComplete()
    {
        if (finishMenu.activeSelf)
        {
            finishMenu.SetActive(false);
        }
        else
        {
            finishMenu.SetActive(true);
        }
    }

    public void returnToMainMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine(fadeOut(0));
    }

    public void ContinueToNextLevel()
    {
        Time.timeScale = 1f;
        var levelToLoad = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        Debug.Log(levelToLoad);
        StartCoroutine(fadeOut(levelToLoad));
    }

    public IEnumerator fadeOut(int sceneIndex)
    {
        float alpha = 0;

        //float fadeOutTime = .5f;

        while (alpha < 1)
        {
            // Debug.Log(fadeImage.color.a);
            Color temp = fadeImage.color;
            temp.a = alpha;
            fadeImage.color = temp;
            alpha += .03f;
            //Debug.Log(alpha);
            yield return new WaitForSeconds(.01f);
        }

        SceneManager.LoadScene(sceneIndex);


    }
}
