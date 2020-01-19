using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScript : MonoBehaviour
{
    public ThrowBall r3;
    public Animator Animator;

    // Update is called once per frame
    void Update()
    {
        if (r3.WasLaunched)
        {
            StartCoroutine(WaitToEnd());
        }
    }

    IEnumerator WaitToEnd()
    {
        yield return new WaitForSeconds(2f);
        Animator.SetTrigger("Flare");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("The_End");
    }
}
