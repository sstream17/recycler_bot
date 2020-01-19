using UnityEngine;

public class Receptacle : MonoBehaviour
{
    public RefuseType Type;
    public Score Score;

    private int reward = 10;
    private bool isHardMode = false;

    private void Start()
    {
        isHardMode = PlayerPrefs.GetInt("hardMode", -1) == 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RefuseObject refuseObject = collision.GetComponent<RefuseObject>();

        if (refuseObject != null)
        {
            if (refuseObject.Type.Equals(Type))
            {
                Score.AddScore(Score.Multiplier * reward);
                Score.Streak += 1;
            }
            else
            {
                var negativeReward = -reward;
                if (isHardMode)
                {
                    negativeReward = Score.Multiplier * negativeReward;
                }

                Score.AddScore(negativeReward);
                Score.Streak = 0;
            }

            Destroy(collision.gameObject);
        }
    }
}
