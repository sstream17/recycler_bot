using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public Ball Ball;

    public Vector2 CalculateTrajectory(float initialX, float initialY)
    {
        return new Vector2(initialX, initialY);
    }
}
