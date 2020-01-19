using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public ThrowBall ThrowBall;
    public GameObject TrajectoryDot;

    private int predictions = 10;
    private List<GameObject> dots = new List<GameObject>();
    private float gravity;
    private bool enableDots = true;

    private void Start()
    {
        gravity = Mathf.Abs(Physics2D.gravity.y);
        for (int i = 0; i < predictions / 2; i++)
        {
            var dot = Instantiate(TrajectoryDot, ThrowBall.transform);
            dots.Add(dot);
        }
    }

    private void Update()
    {
        if (ThrowBall.IsPressed)
        {
            if (enableDots)
            {
                EnableDots();
            }

            CalculateTrajectory(ThrowBall.Angle, ThrowBall.Velocity);
        }
        else if (DotsEnabled())
        {
            DisableDots();
        }
    }

    void CalculateTrajectory(float angle, float velocity)
    {
        var maxDistance = (Mathf.Pow(velocity, 2) * Mathf.Sin(2 * angle)) / gravity;

        for (int i = 0; i < predictions / 2; i++)
        {
            float time = (float)i / predictions;
            var x = time * maxDistance;
            var y = x * Mathf.Tan(angle) - (gravity * Mathf.Pow(x, 2) / (2 * Mathf.Pow(velocity, 2) *  Mathf.Pow(Mathf.Cos(angle), 2)));
            if (float.IsNaN(y))
            {
                y = 0f;
            }

            var position = (Vector2)ThrowBall.transform.position + new Vector2(x, y);
            dots[i].transform.position = position;
            var size = 1f / (i + 1);
            dots[i].transform.localScale = new Vector2(size, size);
        }
    }

    private void EnableDots()
    {
        foreach (var dot in dots)
        {
            SpriteRenderer spriteRenderer = dot.GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = true;
        }

        enableDots = false;
    }

    private void DisableDots()
    {
        foreach (var dot in dots)
        {
            SpriteRenderer spriteRenderer = dot.GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;
        }

        enableDots = true;
    }

    private bool DotsEnabled()
    {
        return dots.Any(dot => dot.GetComponent<SpriteRenderer>().enabled);
    }
}
