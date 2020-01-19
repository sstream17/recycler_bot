using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{

    public DialogueManager dialogueManager;

    public Image earth;

    private bool earthAnimation = true;
    private int count = 0;
    private bool up = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(intro());
        if (PlayerPrefs.GetInt("currentLevel") == 0)
        {
            SaveGame.Save(1);
        }
    }


    // Update is called once per frame
    void Update()
    {
        moveEarth();
    }

    public void moveEarth()
    {
        if (count < 80 && up)
        {
            earth.transform.Translate(Vector2.up * Time.deltaTime * 10);
            count++;
        }
        else if (count < 80 && !up)
        {
            earth.transform.Translate(Vector2.down * Time.deltaTime * 10);
            count++;
        }
        else
        {
            count = 0;
            if (up)
            {
                up = false;
            }
            else
            {
                up = true;
            }
        }
    }

    IEnumerator intro()
    {

        yield return new WaitForSeconds(2f);

        string[] text = {"The year is 2200. The world has been <color=red>ruined<color=white> by big corperations outlawing recycling",
            "As generations passed people had forgotten what it means to <color=green>Reduce, reuse, and recycle<color=white>.",
            "There is a small spark of hope. An android named R3 has mysteriously appeared in society, destined to teach the people of the old ways",
            "Humanities last hope is left up to a small robot..." };
        dialogueManager.setText(text, "Narrator");
        

        yield return null;
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene("Level_1");
    }
}
