using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story3Handler : MonoBehaviour
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

        string[] text = { "Way to go R3!Now lets really kick things into gear by adding compost and plastic into the mix!",
              "Compost can be collected by old foods such as a banana peel! Put the banana peel into the compost bin!",
        "Plastics such as recyclable water bottles can be sorted into the <color=red>red<color=white> recycling bin! Give it your best shot R3!"};
        dialogueManager.setText(text, "Narrator");


        yield return null;
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene("Level_5");
    }
}