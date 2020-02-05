using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public Rigidbody2D Rb;
    public CapsuleCollider2D Collider;
    public float thrustMultiplier = 10f;
    public bool IsPressed = false;
    public float Angle;
    public float Velocity;
    public bool WasLaunched = false;

    private Vector2 startPosition;
    private Camera mainCamera;
    private Vector2 force;
    private float torque = 10f;
    private float throwingAreaBorderRight = -6.0f;
    private float throwingAreaBorderBottom = -5.0f;

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
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Rb.position = new Vector3(Mathf.Min(mousePosition.x, throwingAreaBorderRight), Mathf.Max(mousePosition.y, throwingAreaBorderBottom));
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
        WasLaunched = true;
        Rb.velocity = force;
        Rb.AddTorque(torque);
        Collider.enabled = true;
        Destroy(gameObject, 5f);
    }

    Vector2 CalculateForces()
    {
        var x = transform.position.x;
        var y = transform.position.y;
        return startPosition - new Vector2(x, y);
    }
}