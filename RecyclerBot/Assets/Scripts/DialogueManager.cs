using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public GameObject dialogueBox;
    public TextMeshProUGUI dialogue;
    public TextMeshProUGUI speaker;
    public TextMeshProUGUI clickToContinue;
    public bool dialogueIsActive;

    private bool textIsScrolling;
    private bool allMessagesDisplayed;

    private string[] dialogueArray;
    private string currentText;
    private int currentTextIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        allMessagesDisplayed = false;
        dialogueIsActive = false;
        dialogueBox.SetActive(false);
        clickToContinue.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the player clicks when the text has finished scrolling
        if(dialogueIsActive && Input.GetMouseButtonDown(0) && !textIsScrolling)
        {
            clickToContinue.text = "";

            //Disables box if all text has been displayed
            if (allMessagesDisplayed)
            {
                dialogueIsActive = false;
                dialogueBox.SetActive(false);
            }
            //If there is more text, increases the index and displays the next set of text
            else
            {
                currentTextIndex++;
                nextText();
            }
            

        }
        //Checks if the player clicks when the text has not finished scrolling
        else if(dialogueIsActive && Input.GetMouseButtonDown(0) && textIsScrolling)
        {
            //Stops Coroutines and auto finishes the text
            StopAllCoroutines();
            dialogue.text = currentText;
            textIsScrolling = false;
            clickToContinue.text = "Click to Continue...";
        }
        
    }

    //Function that sets up the dialogue
    public void setText(string[] textArray, string speakerName)
    {
        Debug.Log("Setting Text");
        dialogueIsActive = true;
        dialogueBox.SetActive(true);
        speaker.text = speakerName+":";
        dialogueArray = textArray;
        currentTextIndex = 0;
        allMessagesDisplayed = false;
        
        nextText();

    }

    //Displays the next text based off the current index
    public void nextText()
    {

        if (currentTextIndex == dialogueArray.Length-1)
        {
            allMessagesDisplayed = true;
        }

        dialogue.text = "";
        currentText = dialogueArray[currentTextIndex];
        StartCoroutine(scrollText());
    }

    public void testText()
    {
           string[] message = { "Hello<color=blue> world<color=white>, very nice to meet you all!", "... ... ...", "I love CornHacks 2020!"};
        setText( message, "Spencer");

        //string[] message = { "Hello?, What do we have here?", "A <color=blue>friend<color=white>?" };
        //setText(message, "Unknown");
    }

    private IEnumerator scrollText()
    {
        textIsScrolling = true;

        bool tag = false;
        string hiddenText = "";
        for (int i = 0 ; i < currentText.Length; i++)
        {
           
            hiddenText += currentText[i];
            //Debug.Log(hiddenText);

            if (currentText[i].CompareTo('<') == 0)
            {
                tag = true;
            }

            if (!tag)
            {
                dialogue.text = hiddenText;
            }


            if (currentText[i].CompareTo('>') == 0)
            {
                tag = false;
            }

            if (tag)
            {
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(.02f);
            }
            
        }

        textIsScrolling = false;
        clickToContinue.text = "Click to Continue...";

    }
}
