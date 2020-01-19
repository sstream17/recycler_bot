using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinallyHandler : MonoBehaviour
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

        string[] text = { "R3 has officially recycled and cleaned up all the waste humans left behind. Humans have returned and learned how valuable and necessary recycling truly is.",
            "They overthrew the big corporations and started teaching kids in school about green initiatives. But with all this said and done, what is left for our R3 to do?",
            "Well R3 you did it! What will you do with all your free time now that there is nothing else to recycle?",
            "For one last selfless act for humanity. R3 has decided to recycle itself. Thank you for everything r3!"
        };
        dialogueManager.setText(text, "Narrator");


        yield return null;
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene(0);
    }
}