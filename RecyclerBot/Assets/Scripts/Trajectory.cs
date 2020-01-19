using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public ThrowBall ThrowBall;
    public float TimeStep = 1f;
    public int Predictions = 10;
    public GameObject TrajectoryDot;

    private List<GameObject> dots = new List<GameObject>();
    private float initialX;
    private float initialY;
    private bool enableDots = true;

    private void Start()
    {
        for (int i = 0; i < Predictions; i++)
        {
            var dot = Instantiate(TrajectoryDot, transform);
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

            initialX = ThrowBall.X;
            initialY = ThrowBall.Y;
            CalculateTrajectory(0f, 0f, initialX, initialY);
        }
        else if (DotsEnabled())
        {
            DisableDots();
        }
    }

    public Vector2 CalculateTrajectory(
        float initialVelocityX,
        float initialVelocityY,
        float initialPositionX = 0f,
        float initialPositionY = 0f)
    {
        var gravity = Physics2D.gravity.y;
        for (int i = Predictions - 1; i >= 0; i--)
        {
            var time = TimeStep / (i + 1);
            var yTime = initialPositionY + initialVelocityY * time + (0.5f * gravity * Mathf.Pow(i, 2));
            var xTime = initialPositionX + initialVelocityX * time;
            dots[i].transform.position = new Vector2(xTime, yTime);
            var size = 1f / Predictions;
            dots[i].transform.localScale = new Vector2(size, size);
        }

        return new Vector2(initialVelocityX, initialVelocityY);
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
            spriteRenderer.enabled = true;
        }

        enableDots = true;
    }

    private bool DotsEnabled()
    {
        return dots.Any(dot => dot.GetComponent<SpriteRenderer>().enabled);
    }
}
