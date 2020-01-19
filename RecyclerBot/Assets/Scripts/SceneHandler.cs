using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{

    public Image fadeImage;
    public Image earth;
    public Image exit;
    public Image arrow;
    
    // Start is called before the first frame update
    void Start()
    {
        earth.enabled = false;
        exit.enabled = false;
        arrow.enabled = false;
        if (!PlayerPrefs.HasKey("currentLevel"))
        {
            Debug.Log("Didn't find a saved game");
            GameObject.Find("Main_Menu_UI/Level_Select_Button").GetComponent<Button>().interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        earth.transform.Rotate(Vector3.up, 5f);
        exit.transform.Rotate(Vector3.up, 5f);
        arrow.transform.Rotate(Vector3.left, 5f);
    }

    public void hover(string button)
    {
        if(button.CompareTo("play") == 0)
        {
            earth.enabled = true;
        }
        if(button.CompareTo("exit") == 0)
        {
            exit.enabled = true;
        }
        if(button.CompareTo("arrow") == 0)
        {
            arrow.enabled = true;
        }
    }

    public void exitHover()
    {
        earth.enabled = false;
        exit.enabled = false;
        arrow.enabled = false;
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
            alpha += .03f;
            //Debug.Log(alpha);
            yield return new WaitForSeconds(.01f);
        }

        SceneManager.LoadScene(sceneIndex);


    }
}
