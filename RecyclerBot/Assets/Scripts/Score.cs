using UnityEngine;
using TMPro;
using System.Collections;
using System;

public class Score : MonoBehaviour
{
    public int CurrentScore = 0;
    public int Streak = 0;
    public int Multiplier = 1;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI TimeText;
    public float Time = 60f;
    public bool TimerFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerFinished)
        {
            // Disable input

            // Pause
            UnityEngine.Time.timeScale = 0f;

            // Show menu

        }

        Multiplier = Streak / 3;

        TimeText.text = FormatTime(Time);
        ScoreText.text = CurrentScore.ToString();
    }

    public void AddScore(int score)
    {
        CurrentScore += score;
    }

    IEnumerator Timer()
    {
        while (Time > 0f)
        {
            yield return new WaitForSeconds(1f);
            Time--;
        }

        TimerFinished = true;
    }

    private string FormatTime(float time)
    {
        var timeString = $"{TimeSpan.FromSeconds(Time)}";
        return timeString.Remove(0, 3);
    }
}
