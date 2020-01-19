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
    public GameObject Refuse;

    private bool levelFinished = false;
    private bool searchingForRefuse = false;

    // Start is called before the first frame update
    void Start()
    {
        LevelText.text = $"Level {CurrentLevel}";
        StartCoroutine(Timer());
        if (Refuse == null)
        {
            if (!searchingForRefuse)
            {
                searchingForRefuse = true;
                StartCoroutine(SearchForRefuse());
            }
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time < 3)
        {
            if (Refuse == null)
            {
                if (!searchingForRefuse)
                {
                    searchingForRefuse = true;
                    StartCoroutine(SearchForRefuse());
                }
                return;
            }
        }

        if (TimerFinished)
        {
            if (!levelFinished)
            {
                levelFinished = true;
                StartCoroutine(WaitForBuzzerBeater(Refuse));
            }
            
        }

        Multiplier = Streak / 3 == 0 ? 1 : Streak / 3;

        TimeText.text = FormatTime();
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

    private string FormatTime()
    {
        var timeString = $"{TimeSpan.FromSeconds(Time)}";
        return timeString.Remove(0, 3);
    }

    IEnumerator SearchForRefuse()
    {
        GameObject searchResult = GameObject.FindGameObjectWithTag("Refuse");
        if (searchResult == null)
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(SearchForRefuse());
        }
        else
        {
            searchingForRefuse = false;
            Refuse = searchResult;
            yield return false;
        }
    }

    IEnumerator WaitForBuzzerBeater(GameObject refuse)
    {
        if (refuse && refuse.GetComponent<ThrowBall>().WasLaunched)
        {
            while (refuse)
            {
                yield return new WaitForEndOfFrame();
            }
        }

        UnityEngine.Time.timeScale = 0f;
        UIHandler.OnLevelComplete(CurrentScore, CurrentLevel + 1);
    }
}
