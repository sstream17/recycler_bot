using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectHandler : MonoBehaviour
{

    public Image fadeImage;
    // Start is called before the first frame update
    void Start()
    {
        disableLevels();
        loadLevels();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScene(int sceneIndex)
    {
        StartCoroutine(fadeOut(sceneIndex));
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

    public void disableLevels()
    {
        for(int i = 0; i < 2; i++)
        {
            Button b = GameObject.Find("Canvas/Level_Holder/Level_" + (i + 1)).GetComponent<Button>();
            b.interactable = false;
        }
    }
    public void loadLevels()
    {
        int level = PlayerPrefs.GetInt("lastLevelCompleted");
        Debug.Log("Loading levels... " + level);
        for(int i = 0; i < level; i++)
        {
            Button b = GameObject.Find("Canvas/Level_Holder/Level_" + (i+1)).GetComponent<Button>();
            b.interactable = true;
            
        }
    }

    public void initPrefs()
    {
        PlayerPrefs.SetInt("lastLevelCompleted", 1);
        Debug.Log("Set Prefs");
    }
}
