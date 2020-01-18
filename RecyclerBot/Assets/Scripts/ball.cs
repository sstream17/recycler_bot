using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpringJoint2D Spring;
    public Rigidbody2D Hook;
    public float releaseTime = .15f;

    private bool isPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        var hookGameObject = GameObject.FindGameObjectWithTag("Hook");
        Hook = hookGameObject.GetComponent<Rigidbody2D>();
        Spring.connectedBody = Hook;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;

        StartCoroutine(Release()); 
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
    }
}
