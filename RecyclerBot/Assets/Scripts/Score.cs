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
    public TextMeshProUGUI LevelText;
    public float Time = 60f;
    public bool TimerFinished = false;
    public UIHandler UIHandler;
    public int CurrentLevel;

    private bool levelFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        LevelText.text = $"Level {CurrentLevel}";
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerFinished)
        {
            if (!levelFinished)
            {
                levelFinished = true;
                UnityEngine.Time.timeScale = 0f;
                UIHandler.OnLevelComplete(CurrentScore, CurrentLevel);
            }
            
        }

        Multiplier = Streak / 3 == 0 ? 1 : Streak / 3;

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
