using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public Rigidbody2D Rb;
    public float thrustMultiplier = 500f;
    public float X;
    public float Y;
    public Vector2 InitialPosition;
    public bool IsPressed = false;

    private Vector2 startPosition;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        InitialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPressed)
        {
            Rb.position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            X = transform.position.x;
            Y = transform.position.y;
        }
    }

    void OnMouseDown()
    {
        startPosition = new Vector2(GetComponent<Rigidbody2D>().transform.position.x, GetComponent<Rigidbody2D>().transform.position.y);
        IsPressed = true;
        GetComponent<Rigidbody2D>().gravityScale = 1f;
    }

    void OnMouseUp()
    {
        Throw();
        IsPressed = false;
    }

    void Throw()
    {
        Vector2 forces = CalculateForces();
        Debug.Log(forces * thrustMultiplier);
        Rb.AddForce(forces * thrustMultiplier);
    }

    Vector2 CalculateForces()
    {
        return startPosition - new Vector2(X, Y);
    }
}