using UnityEngine;

public class HardModePref : MonoBehaviour
{
    private void Start()
    {
        if (Score.Instance)
        {
            Score.Instance.RunningScore = 0;
            Score.Instance.CurrentScore = 0;
        }
    }
    public void DisableHardMode()
    {
        PlayerPrefs.SetInt("hardMode", -1);
    }
}
