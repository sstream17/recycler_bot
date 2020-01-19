using System.Collections;
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
