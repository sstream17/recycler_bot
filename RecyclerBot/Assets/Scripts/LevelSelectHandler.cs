using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelectHandler : MonoBehaviour
{

    public Image fadeImage;
    public TextMeshProUGUI HardModeText;

    // Start is called before the first frame update
    void Start()
    {
        HardModeText.text = PlayerPrefs.GetInt("hardMode", -1) == 1 ? "<color=#7D3232>Hard Mode On</color>" : "<color=#323232>Hard Mode Off</color>";
        disableLevels();
        loadLevels();
        //initPrefs();
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
        for (int i = 0; i < 8; i++)
        {
            Button b = GameObject.Find("Canvas/Level_Holder/Level_" + (i + 1)).GetComponent<Button>();
            b.interactable = false;
        }

        for (int j = 0; j < 4; j++)
        {
            Button s = GameObject.Find("Canvas/Level_Holder/Story_" + (j + 1)).GetComponent<Button>();
            s.interactable = false;
        }

        Button f = GameObject.Find("Canvas/Finally_Button").GetComponent<Button>();
        f.interactable = false;


    }
    public void loadLevels()
    {
        int level = PlayerPrefs.GetInt("currentLevel");
        Debug.Log("Loading levels... " + level);
        for (int i = 0; i < level; i++)
        {
            if (i < 8)
            {
                Debug.Log("Activating Button: " + i);
                Button b = GameObject.Find("Canvas/Level_Holder/Level_" + (i + 1)).GetComponent<Button>();
                b.interactable = true;

                if (level > 0)
                {
                    Button s = GameObject.Find("Canvas/Level_Holder/Story_1").GetComponent<Button>();
                    s.interactable = true;
                }
                if (level > 2)
                {
                    Button s = GameObject.Find("Canvas/Level_Holder/Story_2").GetComponent<Button>();
                    s.interactable = true;
                }
                if (level > 4)
                {
                    Button s = GameObject.Find("Canvas/Level_Holder/Story_3").GetComponent<Button>();
                    s.interactable = true;
                }
                if (level > 6)
                {
                    Button s = GameObject.Find("Canvas/Level_Holder/Story_4").GetComponent<Button>();
                    s.interactable = true;
                }
            }
            if (level == 9)
            {
                Button f = GameObject.Find("Canvas/Finally_Button").GetComponent<Button>();
                f.interactable = true;
            }
        }

    }

    public void initPrefs()
    {
        PlayerPrefs.SetInt("currentLevel", 9);
    }
    public void loadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ToggleHardMode()
    {
        if (PlayerPrefs.GetInt("hardMode", -1) == 1)
        {
            PlayerPrefs.SetInt("hardMode", -1);
            HardModeText.text = "<color=#323232>Hard Mode Off</color>";
        }
        else
        {
            PlayerPrefs.SetInt("hardMode", 1);
            HardModeText.text = "<color=#7D3232>Hard Mode On</color>";
        }
    }
}
