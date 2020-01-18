using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public GameObject[] RefuseObjects;
    public GameObject RefuseToLaunch;
    public Transform Launcher;
    public Transform SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        RefuseToLaunch = GetRandomRefuseObject();
        SpawnRefuseObjectToLaunch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject GetRandomRefuseObject()
    {
        int randomObject = (int)Mathf.Floor(Random.value * RefuseObjects.Length);
        return RefuseObjects[randomObject];
    }

    private void SpawnRefuseObjectToLaunch()
    {
        Instantiate(RefuseToLaunch, SpawnPoint.position, Quaternion.identity, Launcher);
    }
}
