using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{

    public Image fadeImage;
    public Image earth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        earth.transform.Rotate(Vector3.up, 5f);
    }

    public void hover()
    {

    }

    public void changeScene(int sceneIndex)
    {
        StartCoroutine(fadeOut(sceneIndex));
    
    }

    public void exitGame()
    {
        Application.Quit();
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
            alpha += .01f;
            //Debug.Log(alpha);
            yield return new WaitForSeconds(.01f);
        }

        SceneManager.LoadScene("Intro_Story");


    }
}
