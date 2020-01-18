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
