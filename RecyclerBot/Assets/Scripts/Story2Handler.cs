using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story2Handler : MonoBehaviour
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

        string[] text = {"The air has already gotten cleaner, and the smog has cleared! Grass has started growing...",
            "You’re doing so well already R3! It’s time to learn about even more items you can recycle. <color=green>Green<color=white> glass bottles go into the <color=green>green<color=white> bin. Tin can go into the <color=yellow>yellow<color=white> bins!",
        "Let's try it now!"};
        dialogueManager.setText(text, "Narrator");


        yield return null;
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene("Level_3");
    }
}

