using UnityEngine;

public class Receptacle : MonoBehaviour
{
    public RefuseType Type;
    public Score Score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RefuseObject refuseObject = collision.GetComponent<RefuseObject>();

        if (refuseObject != null)
        {
            if (refuseObject.Type.Equals(Type))
            {
                Score.AddScore(Score.Multiplier * 10);
                Score.Streak += 1;
            }
            else
            {
                Score.AddScore(-10);
                Score.Streak = 0;
            }

            Destroy(collision.gameObject);
        }
    }
}
