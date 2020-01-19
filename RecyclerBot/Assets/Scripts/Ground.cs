using System.Collections;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject Refuse;
    public Score Score;

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
            if (Refuse.transform.position.y < -5f)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RefuseObject refuseObject = collision.GetComponent<RefuseObject>();

        if (refuseObject != null)
        {
            OnShotMissed(refuseObject.gameObject);
        }
    }
}
