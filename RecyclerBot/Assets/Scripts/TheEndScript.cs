﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEndScript : MonoBehaviour
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

        string[] text = {
            "Thanks for playing! The End"
        };
        dialogueManager.setText(text, "Narrator");


        yield return null;
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene(0);
    }
}
