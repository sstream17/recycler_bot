using System.Collections;
using TMPro;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public GameObject[] RefuseObjects;
    public GameObject RefuseToLaunch;
    public Transform Launcher;
    public Transform SpawnPoint;

    private GameObject refuseInstance;

    // Start is called before the first frame update
    void Start()
    {
        Score.Instance.Time = 60f;
        Score.Instance.TimerFinished = false;
        Score.Instance.LevelFinished = false;
        Score.Instance.StartCoroutine(Score.Instance.Timer());
        Score.Instance.ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        Score.Instance.TimeText = GameObject.FindGameObjectWithTag("TimeText").GetComponent<TextMeshProUGUI>();
        Score.Instance.LevelText = GameObject.FindGameObjectWithTag("LevelText").GetComponent<TextMeshProUGUI>();
        Score.Instance.UIHandler = GameObject.FindGameObjectWithTag("UIHandler").GetComponent<UIHandler>();
        Score.Instance.LevelText.text = $"Level {Score.Instance.CurrentLevel}";
        SpawnRandomRefuse();
    }

    IEnumerator WaitToSpawnNextRefuse()
    {
        while (refuseInstance)
        {
            yield return new WaitForEndOfFrame();
        }

        SpawnRandomRefuse();
    }

    private void SpawnRandomRefuse()
    {
        int randomObject = (int)Mathf.Floor(Random.value * RefuseObjects.Length);
        RefuseToLaunch = RefuseObjects[randomObject];
        refuseInstance = Instantiate(RefuseToLaunch, SpawnPoint.position, Quaternion.identity, Launcher);
        StartCoroutine(WaitToSpawnNextRefuse());
    }
}
