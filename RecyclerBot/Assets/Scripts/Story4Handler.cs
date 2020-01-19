using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story4Handler : MonoBehaviour
{
    public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(intro());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator intro()
    {

        yield return new WaitForSeconds(2f);

        string[] text = { "Trees are growing big and strong while people have returned to the streets! All of R3’s efforts have been a complete success!",
        "R3 you’ve done so much for us, soon your mission will come to an end and you can retire nicely! We love you R3, keep going!"};
        dialogueManager.setText(text, "Narrator");


        yield return null;
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene("Level_7");
    }
}