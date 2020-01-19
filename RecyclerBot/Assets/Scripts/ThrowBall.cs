using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public Rigidbody2D Rb;
    public CapsuleCollider2D Collider;
    public float thrustMultiplier = 10f;
    public bool IsPressed = false;
    public float Angle;
    public float Velocity;

    private Vector2 startPosition;
    private Camera mainCamera;
    private Vector2 force;
    private float torque = 10f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPressed)
        {
            Collider.enabled = false;
            Rb.position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 forces = CalculateForces();
            force = forces * thrustMultiplier;
            Velocity = force.magnitude;
            Angle = Mathf.Atan2(force.y, force.x);
        }
    }

    void OnMouseDown()
    {
        startPosition = new Vector2(transform.position.x, transform.position.y);
        IsPressed = true;
    }

    void OnMouseUp()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1f;
        Throw();
        IsPressed = false;
    }

    void Throw()
    {
        Rb.velocity = force;
        Rb.AddTorque(torque);
        Collider.enabled = true;
    }

    Vector2 CalculateForces()
    {
        var x = transform.position.x;
        var y = transform.position.y;
        return startPosition - new Vector2(x, y);
    }
}