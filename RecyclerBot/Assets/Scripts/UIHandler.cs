using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{

    public GameObject pauseMenu;
    public Image fadeImage;

    private bool pauseMenuIsActive = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pause()
    {
        Debug.Log("Clicked");
        if (pauseMenuIsActive)
        {
            pauseMenuIsActive = false;
            pauseMenu.SetActive(false);
        }
        else
        {
            pauseMenuIsActive = true;
            pauseMenu.SetActive(true);
        }
    }

    public void returnToMainMenu()
    {
        StartCoroutine(fadeOut(0));
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
