using UnityEngine;

public class Receptacle : MonoBehaviour
{
    public RefuseType Type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RefuseObject refuseObject = collision.GetComponent<RefuseObject>();

        if (refuseObject != null)
        {
            if (refuseObject.Type.Equals(Type))
            {
                Debug.Log("Score");
                Destroy(collision.gameObject);
            }
            else
            {
                Debug.Log("Wrong");
            }
        }
    }
}
