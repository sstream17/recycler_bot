using System.Collections;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject Refuse;
    public Score Score;
    public float LowerBound = -5f;

    private bool searchingForRefuse = false;
    private int reward = 5;
    private bool isHardMode = false;

    // Start is called before the first frame update
    void Start()
    {
        isHardMode = PlayerPrefs.GetInt("hardMode", -1) == 1;
        if (isHardMode)
        {
            reward = reward * 2;
        }

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
        if (Refuse == null)
        {
            if (!searchingForRefuse)
            {
                searchingForRefuse = true;
                StartCoroutine(SearchForRefuse());
            }
            return;
        }

        if (Refuse)
        {
            ThrowBall throwBall = Refuse.GetComponent<ThrowBall>();
            if (throwBall.WasLaunched && Refuse.transform.position.y < LowerBound)
            {
                OnShotMissed(Refuse.gameObject);
            }
        }
    }

    private void OnShotMissed(GameObject gameObjectToDestroy)
    {
        Score.AddScore(-reward);
        Score.Streak = 0;
        Destroy(gameObjectToDestroy);
    }

    IEnumerator SearchForRefuse()
    {
        GameObject searchResult = GameObject.FindGameObjectWithTag("Refuse");
        if (searchResult == null)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(SearchForRefuse());
        }
        else
        {
            searchingForRefuse = false;
            Refuse = searchResult;
            yield return false;
        }
    }
}
