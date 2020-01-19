using System.Collections.Generic;
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

    private void Start()
    {
        for (int i = 0; i < Predictions; i++)
        {
            // Instantiate Dot
            var dot = Instantiate(TrajectoryDot, transform);
            dots.Add(dot);
        }
    }

    private void Update()
    {
        initialX = ThrowBall.transform.position.x;
        initialY = ThrowBall.transform.position.y;
        CalculateTrajectory(initialX, initialY);
    }

    public Vector2 CalculateTrajectory(
        float initialVelocityX,
        float initialVelocityY,
        float initialLength = 0f,
        float initialHeight = 0f)
    {
        var gravity = Physics2D.gravity.y;
        for (int i = Predictions - 1; i >= 0; i--)
        {
            var time = TimeStep / (i + 1);
            var yTime = initialHeight + initialVelocityY * time + (0.5f * gravity * Mathf.Pow(i, 2));
            var xTime = initialLength + initialVelocityX * time;
            dots[i].transform.position = new Vector2(xTime, yTime);
            var size = 1f / Predictions;
            dots[i].transform.localScale = new Vector2(size, size);
        }

        return new Vector2(initialVelocityX, initialVelocityY);
    }
}
