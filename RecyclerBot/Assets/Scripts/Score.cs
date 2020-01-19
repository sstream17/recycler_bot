using UnityEngine;
using TMPro;
using System.Collections;
using System;

public class Score : MonoBehaviour
{
    public static Score Instance;

    public int CurrentScore = 0;
    public int RunningScore = 0;
    public int Streak = 0;
    public int Multiplier = 1;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI LevelText;
    public float Time = 60f;
    public bool TimerFinished = false;
    public bool LevelFinished = false;
    public UIHandler UIHandler;
    public int CurrentLevel;

    private GameObject Refuse;
    private bool searchingForRefuse = false;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        Instance.CurrentScore = 0;
        Instance.Time = 60f;
        Instance.TimerFinished = false;
        Instance.ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        Instance.TimeText = GameObject.FindGameObjectWithTag("TimeText").GetComponent<TextMeshProUGUI>();
        Instance.LevelText = GameObject.FindGameObjectWithTag("LevelText").GetComponent<TextMeshProUGUI>();
        Instance.UIHandler = GameObject.FindGameObjectWithTag("UIHandler").GetComponent<UIHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance.LevelText.text = $"Level {Instance.CurrentLevel}";
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

        if (Instance.TimerFinished)
        {
            if (!Instance.LevelFinished)
            {
                Instance.LevelFinished = true;
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

    public IEnumerator Timer()
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

        Instance.RunningScore += CurrentScore;
        UnityEngine.Time.timeScale = 0f;
        UIHandler.OnLevelComplete(CurrentScore, Instance.RunningScore, CurrentLevel + 1);
        Instance.CurrentLevel += 1;
    }
}
